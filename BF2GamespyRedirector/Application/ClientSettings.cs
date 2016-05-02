using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BF2GamespyRedirector
{
    public static class ClientSettings
    {
        private static string FilePath = Path.Combine(Program.RootPath, "Settings.json");

        private static SettingsContainer Container;

        public static List<ServiceProvider> ServiceProviders
        {
            get { return Container.ServiceProviders; }
        }

        public static List<Server> SavedServers
        {
            get { return Container.SavedServers; }
        }

        public static void Save()
        {
            // serialize JSON directly to a file
            using (FileStream file = File.Open(FilePath, FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter writer = new StreamWriter(file))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(writer, Container);
            }
        }

        public static void Load()
        {
            TraceLog.Write("Loading client settings... ");
            if (Container == null)
            {
                try
                {
                    using (FileStream file = File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
                    using (StreamReader reader = new StreamReader(file))
                    {
                        string contents = reader.ReadToEnd();
                        if (String.IsNullOrWhiteSpace(contents))
                            Container = new SettingsContainer();
                        else
                            Container = JsonConvert.DeserializeObject<SettingsContainer>(contents);

                        TraceLog.WriteLine("Success!");
                    }
                }
                catch (Exception e)
                {
                    TraceLog.WriteLine("Failed!");
                    TraceLog.Indent();
                    TraceLog.TraceError(e.Message);
                    TraceLog.Unindent();
                    Container = new SettingsContainer();
                }

                // Ensure we have the default provider if none others
                if (Container.ServiceProviders.Count == 0)
                {
                    Container.AddDefaultProvider();

                    // Save changes
                    Save();
                }
            }
        }
    }
}
