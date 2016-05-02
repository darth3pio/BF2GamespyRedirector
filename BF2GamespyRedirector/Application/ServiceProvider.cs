using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BF2GamespyRedirector
{
    public class ServiceProvider
    {
        public string Name;

        public string StatsAddress;

        public string GamespyAddress;

        public override string ToString()
        {
            return Name;
        }
    }
}
