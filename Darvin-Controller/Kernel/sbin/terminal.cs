using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Darvin_Controller.Kernel.sbin
{
    class terminal
    {
        // Terminal Vars
        String TBuffer;
        int command;
        String path;
        String Split = ":";
        bool Running = true;

        // Main Facing Method
        public void term(String Cbuffer){
            if (Running)
            {
                // ToDo Read Command Split and process
                return;
            }
        }
    }
}
