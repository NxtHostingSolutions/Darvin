using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO.Ports;
using System.Windows;
using ControlzEx.Standard;

namespace Darvin_Standalone.sys.VCommand
{
    class VCommand
    {
        //Creating objects
        readonly MainWindow mw = new MainWindow();
        SerialPort myPort = new SerialPort();
        SpeechRecognitionEngine re = new SpeechRecognitionEngine();
        SpeechSynthesizer ss = new SpeechSynthesizer(); // When you want program to talk back to you 
        Choices commands = new Choices(); // This is an important class as name suggest we will store our commands in this object

        public void init()
        {
            //Details of Arduino board
            myPort.PortName = "COM3"; // My Port name in Arduino IDE selected COM5 you need to change Port name if it is different  just check in arduinoIDE
            myPort.BaudRate = 9600;  // This Rate is Same as arduino Serial.begin(9600) bits per second
            mw.ComLabel.Content = "COM3";

            processing();
            re.RecognizeAsync(RecognizeMode.Multiple);

        }

        // Defined Function processing where main instruction will be executed ! 
        void processing()
        {
            //First of all storing commands
            commands.Add(new string[] { "Lights On", "Lights Off", "Voice Off","time", "out of the way", "come back" });

            //Now we will create object of Grammer in which we will pass commands as parameter
            Grammar gr = new Grammar(new GrammarBuilder(commands));

            // For more information about below funtions refer to site https://docs.microsoft.com/en-us/dotnet/api/system.speech.recognition?view=netframework-4.7.2
            re.RequestRecognizerUpdate(); // Pause Speech Recognition Engine before loading commands
            re.LoadGrammarAsync(gr);
            re.SetInputToDefaultAudioDevice();// As Name suggest input device builtin microphone or you can also connect earphone etc...
            re.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(re_SpeechRecognized);


        }

        void re_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            MainWindow main = new MainWindow();
            string voice_state = main.voicelabel.Content.ToString();
            switch (e.Result.Text)
            {
                ////For Led State ON 
                // For blue led
                case "Lights On":
                    sendDataToArduino('4');
                    break;
                //For Led State OFF 
                // For blue led
                case "Lights Off":
                    sendDataToArduino('8');
                    break;

                // For red led
                case "Voice Off":
                    MainWindow mainwin = new MainWindow();
                    re.RecognizeAsyncStop();
                    mainwin.voicelabel.Content = "Disabled";
                    ss.SpeakAsync("Voice Input Deactivated");
                    break;

                // For green led
                case "time":
                    sys.Modules.DarvinTime dtime = new Modules.DarvinTime();
                    string nowtime = dtime.gettime();
                    ss.SpeakAsync(nowtime); // speech synthesis object is used for this purpose
                    break;
                case "out of the way":
                    //MainWindow mainw = new MainWindow();
                    //if (mainw.WindowState == WindowState.Normal || mainw.WindowState == WindowState.Maximized)
                    //{
                    //    mainw.WindowState = WindowState.Minimized;
                    //    ss.SpeakAsync("My apologies");
                    //}
                    break;

                case "come back":
                    //MainWindow mainwm = new MainWindow();
                    //if (mainwm.WindowState == WindowState.Minimized)
                    //{
                    //    mainwm.WindowState = WindowState.Normal;
                    //}
                    break;

                case "open entropia":
                    System.Diagnostics.Process.Start("D:\\Games\\Entropia Universe\\bin32\\ClientLoader.exe");
                    ss.Speak("Loading");
                    break;
                // To Exit Program using Voice :)
                case "Exit":
                    //Application.Exit();
                    break;
            }
            MainWindow mw = new MainWindow();
            mw.Log_output += e.Result.Text.ToString() + Environment.NewLine;// Whenever we command arduino text will append and shown in textbox
        }

        void sendDataToArduino(char character)
        {
            myPort.Open();
            myPort.Write(character.ToString());
            myPort.Close();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            re.RecognizeAsyncStop();
            //btnStart.Enabled = true;
            //btnStop.Enabled = false;
            //btnStart.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            re.RecognizeAsync(RecognizeMode.Multiple);
            //btnStop.Enabled = true;
            //btnStart.Enabled = false;
            MessageBox.Show("Voice Recognition Started !", "Information");
        }
    }
}