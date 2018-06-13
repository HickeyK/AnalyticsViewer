using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticsViewer
{
    public interface IAppConfiguration
    {
        string TestString { get; }

        string DatabaseConnection { get; }

        string DatabaseConfigFilename { get; }

        short DatabaseTimeout { get; }
    }
}
