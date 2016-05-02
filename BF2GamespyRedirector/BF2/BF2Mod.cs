using System;
using System.Diagnostics;
using System.IO;
using System.Xml;

namespace BF2GamespyRedirector
{
    public class BF2Mod
    {
        /// <summary>
        /// Returns the Mod's full name
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// Returns the mods folder name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Returns the mods Root folder path
        /// </summary>
        public string RootPath { get; protected set; }

        /// <summary>
        /// Constructs a new BF2Mod object
        /// </summary>
        /// <param name="ModsPath">The full path to the Mods folder</param>
        /// <param name="ModName">THe mod's folder name</param>
        public BF2Mod(string ModsPath, string ModName)
        {
            // Set internal vars
            this.Name = ModName;
            this.RootPath = Path.Combine(ModsPath, ModName);
            string DescFile = Path.Combine(ModsPath, ModName, "mod.desc");

            // Make sure we have a mod description file
            if (!File.Exists(DescFile))
            {
                //Program.ErrorLog.Write("NOTICE: Mod \"" + ModName + "\" Does not contain mod.desc file");
                Trace.TraceWarning("Mod \"" + ModName + "\" Does not contain mod.desc file");
                throw new InvalidModException("Mod \"" + ModName + "\" does not contain a mod.desc file");
            }

            // Get the actual name of the mod
            try
            {
                XmlDocument Desc = new XmlDocument();
                Desc.Load(DescFile);
                XmlNodeList Node = Desc.GetElementsByTagName("title");
                string Name = Node[0].InnerText.Trim();
                if (Name == "MODDESC_BF2_TITLE")
                    this.Title = "Battlefield 2";
                else if (Name == "MODDESC_XP_TITLE")
                    this.Title = "Battlefield 2: Special Forces";
                else
                    this.Title = Name;
            }
            catch(Exception E)
            {
                throw new InvalidModException(
                    "Mod \"" + ModName + "\" contains an invalid Mod.desc file: "
                    + Environment.NewLine + "   " + E.Message, E
                );
            }
        }

        /// <summary>
        /// Returns the Mod's Title
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Title;
        }
    }
}
