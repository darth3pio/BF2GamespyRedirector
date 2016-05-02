using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF2GamespyRedirector
{
    public class Server
    {
        public string Name;

        public string Address;

        public ushort Port;

        public string Provider;

        public override string ToString()
        {
            return Name;
        }
    }
}
