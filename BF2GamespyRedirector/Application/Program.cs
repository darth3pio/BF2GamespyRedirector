using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using BF2GamespyRedirector.Properties;

namespace BF2GamespyRedirector
{
    static class Program
    {
        /// <summary>
        /// Specifies the Program Version
        /// </summary>
        public static readonly Version Version = new Version(1, 0, 0);

        /// <summary>
        /// Specifies the installation directory of this program
        /// </summary>
        public static readonly string RootPath = Application.StartupPath;

        /// <summary>
        /// Gets the Assembly that contains this executing code
        /// </summary>
        public static readonly Assembly Assembly = Assembly.GetExecutingAssembly();

        /// <summary>
        /// The User Config object
        /// </summary>
        public static Settings Config = Settings.Default;

        /// <summary>
        /// Gets the path to the Battlefield 2 Statistics Documents Folder
        /// </summary>
        public static string DocumentsFolder { get; internal set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Application Styles
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Enable Tracelogging
            TraceLog.Init();

            // Define Documents Folder
            DocumentsFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "BF2Statistics"
            );

            // Set Exception Handler
            Application.ThreadException += ExceptionHandler.OnThreadException;
            AppDomain.CurrentDomain.UnhandledException += ExceptionHandler.OnUnhandledException;

            // Run the Main form
            Application.Run(new MainForm());
        }
    }
}
