using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace Darvin_Controller.Kernel.DevicesLayer
{
    class InitHardware
    {
        class MyConsts
        {
            static readonly Guid Controller = new Guid("{8657dc0b-ec55-4600-948e-6e7c573d33a5}");
        }

        public void init(string Device, int command)
        {
            if (Device == "")
            {

            }
            if (Device == "RLM1")
            {
                Room_Light_Matt_1(command);
            }
        }

        void BluetoothConnect(String ComPort, int Baud,String Name, int command, bool response)
        {
            Form1 frm = new Form1();
            SerialPort serialPort = new SerialPort();
            serialPort.BaudRate = Baud;
            serialPort.PortName = ComPort; // Set in Windows
            //serialPort.Open();
            if (!serialPort.IsOpen)
            {
                frm.Service_Log.AppendText("/n"+Name + ": Connection Error");
            }
            while (serialPort.IsOpen)
            {
                // SEND
                serialPort.WriteLine(command.ToString());
                // WRITE THE INCOMING BUFFER TO CONSOLE
                while (serialPort.BytesToRead > 0 & response == true)
                {
                    
                    frm.Service_Log.AppendText("/n" + Name + ": " + serialPort.ReadChar());
                }
                Thread.Sleep(500);
            }
            
        }

        void Room_Light_Matt_1(int command)
        {
            // init bluetooth comm.
            BluetoothConnect("COM9", 9600, "HC-06", command, true);
        }

    }
}
