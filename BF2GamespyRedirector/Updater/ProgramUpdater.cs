using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
using BF2GamespyRedirector.Updater;
using Newtonsoft.Json;

namespace BF2GamespyRedirector
{
    /// <summary>
    /// Auto updater for the Program
    /// </summary>
    public static class ProgramUpdater
    {
        /// <summary>
        /// Path to the Versions file
        /// </summary>
        public static readonly Uri Url = new Uri("https://api.github.com/repos/BF2Statistics/BF2GamespyRedirector/releases?per_page=5");

        /// <summary>
        /// The new updated version
        /// </summary>
        public static Version NewVersion;

        /// <summary>
        /// Indicates whether there is an update avaiable for download
        /// </summary>
        public static bool UpdateAvailable 
        {
            get
            {
                if (NewVersion == null)
                    return false;

                return Program.Version.CompareTo(NewVersion) != 0;
            }
        }

        /// <summary>
        /// Event fired when the update check has completed
        /// </summary>
        public static event EventHandler CheckCompleted;

        /// <summary>
        /// Indicates whether we are currently downloading an update
        /// </summary>
        private static bool IsDownloading = false;

        /// <summary>
        /// The webclient used to make the requests to github
        /// </summary>
        private static WebClient Web;

        /// <summary>
        /// Specifies the path to the new update archive on the client PC
        /// </summary>
        public static string UpdateFileLocation { get; private set; }

        internal static AsyncCompletedEventArgs AsyncArgs { get; set; }

        static ProgramUpdater()
        {
            // By pass SSL Cert checks
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
        }

        /// <summary>
        /// Checks for a new update Async.
        /// </summary>
        public static async void CheckForUpdateAsync()
        {
            try
            {
                await Task.Run(() =>
                {
                    // Use WebClient to download the latest version string
                    using (Web = new WebClient())
                    {
                        // Simulate some headers, Github throws a fit otherwise
                        Web.Headers["User-Agent"] = "BF2GameSpyRedirector v" + Program.Version;
                        Web.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                        Web.Headers["Accept-Language"] = "en-US,en;q=0.8";
                        Web.Proxy = null; // Disable proxy because this can cause slowdown on some machines

                        // Download file
                        string json = Web.DownloadString(Url);

                        // Use our Json.Net library to convert our API string into an object
                        List<GitHubRelease> Releases = JsonConvert.DeserializeObject<List<GitHubRelease>>(json)
                            .Where(x => x.PreRelease == false && x.Draft == false && x.Assets.Count > 0)
                            .OrderByDescending(x => x.Published).ToList();

                        // Parse version
                        if (Releases?.Count > 0)
                            Version.TryParse(Releases[0].TagName, out NewVersion);
                    }
                });
            }
            catch (Exception e)
            {
                TraceLog.TraceWarning("Error occured while trying to fetch the new release version: " + e.Message);
                NewVersion = Program.Version;
            }

            // Fire Check Completed Event
            CheckCompleted(NewVersion, EventArgs.Empty);
        }


        /// <summary>
        /// Downloads the new update from Github Async.
        /// </summary>
        public static Task<bool> DownloadUpdateAsync(Form owner)
        {
            // Show Task Form
            TaskForm.Show(owner, "Downloading Update", "Downloading Update... Please Standby", true);

            // Return the task that will download the update
            return Task.Run(async() =>
            {
                // Returns if there is no update
                if (!UpdateAvailable)
                    return false;

                // Simulate some headers, Github throws a fit otherwise
                Web = new WebClient();
                Web.Headers["User-Agent"] = "BF2GameSpyRedirector v" + Program.Version;
                Web.Headers["Accept"] = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                Web.Headers["Accept-Language"] = "en-US,en;q=0.8";
                Web.Proxy = null; // Disable proxy because this can cause slowdown on some machines

                // Github file location
                string dlString = "https://github.com/BF2Statistics/BF2GamespyRedirector/releases/download/{0}/BF2GamespyRedirector_{0}.zip";
                Uri downloadUrl = new Uri(String.Format(dlString, NewVersion));

                // Path to the Downloaded file
                UpdateFileLocation = Path.Combine(Program.DocumentsFolder, $"BF2GamespyRedirector_{NewVersion}.zip");

                // Show Task Form
                IsDownloading = true;
                TaskForm.Cancelled += TaskForm_Cancelled;
                TaskForm.Progress.Report(new TaskProgressUpdate("Preparing the download..."));

                try
                {
                    // Download the new version Zip file
                    Web.DownloadProgressChanged += Wc_DownloadProgressChanged;
                    Web.DownloadFileCompleted += Wc_DownloadFileCompleted;
                    await Web.DownloadFileTaskAsync(downloadUrl, UpdateFileLocation);
                    return !AsyncArgs.Cancelled;
                }
                catch (WebException e) when (e.Status == WebExceptionStatus.RequestCanceled)
                {
                    // Ignore cancellation requests
                    return false;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    // Close that task form if its open!
                    if (TaskForm.IsOpen)
                        TaskForm.CloseForm();
                }
            });
        }

        /// <summary>
        /// Event called when the Cancel button is pushed on the main form
        /// </summary>
        static void TaskForm_Cancelled(object sender, CancelEventArgs e)
        {
            if (IsDownloading)
            {
                Web.CancelAsync();
            }
        }

        /// <summary>
        /// Event called when the progress of the download has changed
        /// </summary>
        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            TaskForm.Progress.Report(
                new TaskProgressUpdate(
                    String.Format(
                        "Downloaded {0} of {1}", e.BytesReceived.ToFileSize(), e.TotalBytesToReceive.ToFileSize()
                    )
                )
            );
        }

        /// <summary>
        /// Event called when an update file has completed its download
        /// </summary>
        private static void Wc_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // Close task form, and unregister for updates
            TaskForm.Cancelled -= TaskForm_Cancelled;
            TaskForm.CloseForm();
            IsDownloading = false;
            AsyncArgs = e;

            // Dispose webclient
            Web.Dispose();

            // If we cancelled, delete the incomplete file
            if (e.Cancelled)
            {
                // Delete junk files
                if (File.Exists(UpdateFileLocation))
                    File.Delete(UpdateFileLocation);

                return;
            }
        }

        /// <summary>
        /// Runs the steup.exe from the update archive, and closes this application
        /// </summary>
        public static void RunUpdate()
        {
            // Ensure we have an update available, and we didnt cancel the download
            if (!UpdateAvailable || (AsyncArgs?.Cancelled ?? true))
                return;

            // Extract setup.exe
            string exFile = Path.Combine(Program.DocumentsFolder, "setup.exe");
            using (ZipArchive file = ZipFile.Open(UpdateFileLocation, ZipArchiveMode.Read))
            {
                ZipArchiveEntry setupFile = file.Entries.FirstOrDefault(x => x.FullName == "setup.exe");
                if (setupFile != null)
                {
                    // Extract and start the new update installer
                    setupFile.ExtractToFile(exFile, true);
                    Process installer = Process.Start(exFile);
                    installer.WaitForInputIdle();

                    // Exit the application
                    Application.Exit();
                }
                else
                {
                    throw new Exception("The Setup.exe file appears to be missing from the update archive!");
                }
            }
        }
    }
}
