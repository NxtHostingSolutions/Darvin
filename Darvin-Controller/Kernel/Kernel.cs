using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darvin_Controller.Kernel
{
    class Kernel
    {
        // Form1 frm1 = new Form1();  // errors out stackoverflow
        Core.Config config = new Core.Config();
        Core.Globals global = new Core.Globals();
        public String KernVer = "0.1";
        public String Creator = "NxtRoboticSolutions";

        public void Kernel_Startup()
        {
            //frm1.Service_Log.AppendText(global.NL + "Darvin Controller Starting up.");
            
        }
        public void Kernel_SHutdown()
        {

            //frm1.Service_Log.AppendText(global.NL + "Darvin Controller Shutting Down.");

        }

        public void LoadConfig()
        {
            Core.INIFile ini = new Core.INIFile(@"config.ini");

            if (!config.setup)
            {
                Form1 frmkern = new Form1(); 
                frmkern.Service_Log.AppendText(global.NL + "Loading Configuration");
                config.ID = ini.ReadValue("system", "ID");
                config.config_port = ini.ReadValue("system", "PORT");
                config.config_ip = ini.ReadValue("system", "IP");
                config.secpass = ini.ReadValue("security", "secpass");
                config.config_pass = ini.ReadValue("security", "pass");
                frmkern.Service_Log.AppendText(global.NL + "Configuration Loaded");
                config.setup = true;
            }
            else
            {
                Form1 frmkern = new Form1();
                frmkern.Service_Log.AppendText(global.NL + "Configuration is already loaded.");
                return;
            }
        }

    }
}
