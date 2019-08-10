using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darvin_Auth
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Starting Darvins Auth Services");
            Console.WriteLine("Loading Darvins Configuration...");
            Console.WriteLine("Starting Network Services.");
            kern.Networking.SocketLayer.AsynchronousSocketListener.StartListening();
        }
    }
}
