using System;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.Win32;

namespace BF2GamespyRedirector
{
    public static class TraceLog
    {
        /// <summary>
        /// The full path to our Trace log
        /// </summary>
        public static readonly string FilePath = Path.Combine(Program.RootPath, "Application.log");

        /// <summary>
        /// An object used for locking our write operations
        /// </summary>
        private static object _syncObject = new object();

        /// <summary>
        /// Our text writer
        /// </summary>
        private static IndentedTextWriter Writer;

        public static void Init()
        {
            // Test that we are able to open and write to the file
            FileStream fStream = File.Open(FilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
            Writer = new IndentedTextWriter(new StreamWriter(fStream));

            // Write some starting info
            Writer.WriteLine("-------- BF2 Gamespy Redirector Trace Log --------");
            Writer.WriteLine("Logging Start: " + DateTime.Now.ToString());
            Writer.WriteLine("Program Version: " + Program.Version.ToString());
            Writer.WriteLine("OS Version: " + Environment.OSVersion.VersionString);
            Writer.WriteLine("Environment Type: " + ((Environment.Is64BitOperatingSystem) ? "x64" : "x86"));
            Writer.WriteLine("Installed .NET Versions:");
            Writer.Indent++;
            try
            {
                string path = @"SOFTWARE\Microsoft\NET Framework Setup\NDP";
                RegistryKey InstalledVersions = Registry.LocalMachine.OpenSubKey(path);
                string[] versions = InstalledVersions.GetSubKeyNames();

                for (int i = 0; i < versions.Length; i++)
                    Writer.WriteLine(versions[i].ToString() + " SP" + InstalledVersions.OpenSubKey(versions[i]).GetValue("SP"));
            }
            catch (Exception e)
            {
                Writer.WriteLine("ERROR: " + e.Message);
            }

            Writer.Indent--;
            Writer.Flush();
        }

        public static void TraceInfo(string Message, bool IncludeDate = false)
        {
            WriteTrace("INFO: ", Message, IncludeDate);
        }

        public static void TraceWarning(string Message, bool IncludeDate = false)
        {
            WriteTrace("WARNING: ", Message, IncludeDate);
        }
        public static void TraceError(string Message, bool IncludeDate = false)
        {
            WriteTrace("ERROR: ", Message, IncludeDate);
        }

        public static void Write(string Message, bool Flush = false)
        {
            lock (_syncObject)
            {
                Writer.Write(Message);
                if (Flush)
                    Writer.Flush();
            }
        }

        public static void WriteLine(string Message, bool IncludeDate = false)
        {
            WriteTrace("", Message, IncludeDate);
        }

        private static void WriteTrace(string Prefix, string Message, bool IncludeDate = false)
        {
            lock (_syncObject)
            {
                if (Prefix.Length > 0)
                    Writer.Write(Prefix);

                Writer.WriteLine(Message);
                if (IncludeDate)
                {
                    Writer.Indent++;
                    Writer.WriteLine("Date: " + DateTime.Now.ToString());
                    Writer.Indent--;
                }

                Writer.Flush();
            }
        }

        public static void Indent()
        {
            lock (_syncObject)
                Writer.Indent++;
        }

        public static void Unindent(bool toZero = false)
        {
            if (Writer.Indent > 0)
            {
                lock (_syncObject)
                {
                    if (toZero)
                        Writer.Indent = 0;
                    else
                        Writer.Indent--;
                }
            }
        }
    }
}
