using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darvin_Controller.Kernel.Core
{
    class Commands
    {
        Globals global = new Globals();
        Kernel kern = new Kernel();
        void command_struct(int command)
        {
            if(command != 0){
                switch (command)
                {
                    case 1:
                        kern.Kernel_Startup();
                        break;
                    case 2:
                        kern.Kernel_SHutdown();
                        break;
                    default: 
                        Form1 frm1 = new Form1();
                        frm1.Service_Log.AppendText(global.NL+"Command Not Valid.");
                        break;

                    }
                }
            }
        }
    
}
