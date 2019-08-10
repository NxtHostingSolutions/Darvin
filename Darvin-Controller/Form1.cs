using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Darvin_Controller
{
    public partial class Form1 : Form
    {
        String Ver = "0.1\r\n";

        // Load Service Kernel
        Kernel.Kernel kern = new Kernel.Kernel();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Kernel.NetWorking.SocketCore.ExecuteClient();
            Kernel.DevicesLayer.InitHardware init_hw = new Kernel.DevicesLayer.InitHardware();
            init_hw.init("RLM1", 8);

            Service_Log.Text = "Darvin Service Controller Version: "+Ver;
            Service_Log.AppendText("Darvin Kernel Version " + kern.KernVer);
            kern.LoadConfig();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDevices FD = new FormDevices();
            FD.Visible = true;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
