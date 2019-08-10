using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarvinCore.routines.scheduler
{
    class scheduler
    {
        string time;
        public string get_time()
        {
            time = DateTime.Now.ToString("h:mm:ss tt");
            return time;
        }

        public int day_num()
        {
            return 0;
        }

        public int temp_out()
        {
            return 0;
        }


    }
}
