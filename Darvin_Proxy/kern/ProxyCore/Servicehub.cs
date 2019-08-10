using Darvin_Proxy.kern.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darvin_Proxy.kern.ProxyCore
{
    class Servicehub
    {
        kern.ProxyCore.Proxy proxy = new Proxy();
        public class Darvin_HeartBeat
        {
            // Darvin_Auth Service
            public string auth_Message = "Auth,HeartBeat";
            // Darvin_Auth Status
            public string auth_Status = "";

            // Darvin_Core Service
            public string Core_Message = "Core,HeartBeat";
            // Darvin_Core Status
            public string Core_Status = "";
           
        }

        public string Process(string data)
        {
            string phrase = data;
            string[] words = phrase.Split(',');
            switch (words[0])
            {
                case "Auth":
                    Console.WriteLine("command: " + words[0] + " Running...... Data: " + words[1]);
                    return auth_processor(data);
                   //break;

                case "Control":
                    return "";
                    //break;

                case "Request":
                    return "";
                    //break;
                case "default":
                    return "";
                  //break;
                case "HeartBeat":
                    return HeartBeat_processor(data);
                    //break;
            }
            return "";
        }

        public string auth_processor(string data)
        {
            return "ok!";
        }

        public string HeartBeat_processor(string data)
        {
            Darvin_HeartBeat heartbeat = new Darvin_HeartBeat();
            if (data == "Auth")
            {
                return heartbeat.auth_Message;
            }
            else
            {
                return "HeartBeat_Error_1";
            }
        }
    }
}
