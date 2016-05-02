using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BF2GamespyRedirector
{
    public enum RedirectRemoveMethod
    {
        OnGameClose,
        OnAppClose,
        Never
    }

    public enum RedirectMode
    {
        HostsFile,
        HostsIcsFile,
        DnsServer
    }
}
