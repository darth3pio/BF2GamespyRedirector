using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF2GamespyRedirector
{
    public class SettingsContainer
    {
        public List<ServiceProvider> ServiceProviders = new List<ServiceProvider>();

        public List<Server> SavedServers = new List<Server>();

        public void AddDefaultProvider()
        {
            // Add defaults
            ServiceProviders.Add(new ServiceProvider()
            {
                Name = "Battlelog.co",
                StatsAddress = "battlelog.co",
                GamespyAddress = "login.bl3.co"
            });
        }
    }
}
