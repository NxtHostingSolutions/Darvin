using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darvin_Auth.kern.etc
{
    class Config
    {
        public string BASE_IP()
        {
            return "192.99.175.24";
        }

        public int BASE_PORT()
        {
            return 46552;
        }

        public string ConnectionString()
        {
            return @"Data Source=localhost;Initial Catalog=Darvin;User ID=Darvin;Password=Linuxs19";
        }
    }
}
