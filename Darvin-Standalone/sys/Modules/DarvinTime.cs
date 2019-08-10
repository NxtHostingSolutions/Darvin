using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darvin_Standalone.sys.Modules
{
    class DarvinTime
    {
        public string gettime()
        {
            DateTime now = DateTime.Now;
            string time = now.GetDateTimeFormats('t')[0];
            return time;
        }
    }
}
