using System;
using System.Collections.Generic;
using System.Text;

namespace Darvin_Proxy.kern.ProxyCore
{
    class Proxy
    {
        kern.etc.Config config = new kern.etc.Config();
        public void init()
        {
            Console.WriteLine(config.Service_Name + " Service Started...");
            string ipaddr = config.BASE_IP.ToString();
            string port = config.client_port.ToString();
            int portint = 0;
            try
            {
                portint = Int32.Parse(port);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{port}'");
            }
            Console.WriteLine("Loading Darvin Configuration");
            Console.WriteLine("Starting up Networking Services");
            kern.Networking.SocketLayer.AsynchronousSocketListener.StartListening();

        }

        void LoadSocket()
        {

        }

        void Auth_Hook()
        {

        }
    }
}
