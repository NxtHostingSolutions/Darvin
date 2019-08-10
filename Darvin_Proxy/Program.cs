using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darvin_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            kern.ProxyCore.Proxy proxy = new kern.ProxyCore.Proxy();
            proxy.init();
            char keypress = Console.ReadKey().KeyChar;
            Console.WriteLine("Listener closed... press 0 to exit");
            if(keypress == '0')
            {
                Console.WriteLine("bye");
            }
            else
            {
                Console.WriteLine("press 0 to exit");
            }
        }
    }
}
