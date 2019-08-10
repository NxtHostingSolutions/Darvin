using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Darvin_Standalone.sys.VCommand;
namespace Darvin_Standalone
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public string Log_output;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // activate voice sub process
            string voice_state = voicelabel.Content.ToString();
            if(voice_state == "Disabled")
            {
                ComLabel.Content = "COM3";
                voicelabel.Content = "Enabled";
                VCommand vc = new VCommand();
                vc.init();
            }
            
        }

        private void Log_output_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
