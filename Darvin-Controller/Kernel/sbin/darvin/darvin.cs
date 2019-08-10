using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
namespace Darvin_Controller.Kernel.sbin.darvin
{
    class darvin
    {
        
        static string IP = "192.99.175.31";
        static int port = 44545;
        static string auth;
        static string key;
        public static readonly string keycode = "OR4411AA2";
        static byte[] commandarray;
        static byte[] auth_key;

        public static string Authentication(string hash)
        {
            WebClient wc = new WebClient();
            auth_key = wc.DownloadData("http://darvin-api.nxthostingsolutions.com/authenticator.php?act="+hash);
            auth = auth_key.ToString();
            return auth;
        }

        public static string Connect_home(string command)
        {
            WebClient wc = new WebClient();
            commandarray = wc.DownloadData("http://darvin-api.nxthostingsolutions.com/home.php?act="+command);
            key = commandarray.ToString();
            return key;
        } 

        public void connect_brain()
        {
            NetWorking.SocketCore.ExecuteClient();

        }

        public void start_darvin(string keycode)
        {
            NetWorking.SocketCore NetSock = new NetWorking.SocketCore();

            //NetSock.opensocket();

            Form1 form1 = new Form1();
            form1.Service_Log.AppendText("Connected to Darvin.\n");
            return;
        }

    }
}
