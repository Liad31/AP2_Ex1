using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;
namespace AP2_Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public ApplicationSettings  settings;
        public StartWindow()
        {
            if (File.Exists("settings.xml"))
            {
                var serializer = new XmlSerializer(typeof(ApplicationSettings));
                using (var reader = XmlReader.Create("settings.xml"))
                {
                    settings= (ApplicationSettings)serializer.Deserialize(reader);
                }
            }
            else
            {
                settings = new ApplicationSettings();
            }
            InitializeComponent();
            this.DataContext = settings;
        }

        private void FlightPathClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "CSV files(*.csv *.xlsx )|*.csv;*.xlsx| Text files (*.txt)| *.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                FlightFileBox.Text= dlg.FileName;
                settings.FlightCsvPath = dlg.FileName;
            }

        }

        private void TrainingPathClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter = "CSV files(*.csv *.xlsx )|*.csv;*.xlsx| Text files (*.txt)| *.txt";
            Nullable<bool> result = dlg.ShowDialog();
            
            if (result == true)
            {
                TrainingFileBox.Text= dlg.FileName;
                settings.TrainingCsvPath = dlg.FileName;
            }
        }
        
        private void FlightGearPathClick(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.Filter="flight gear executable | fgfs.exe| executable files (*.exe)|*.exe";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                FlightGearPathBox.Text= dlg.FileName;
                settings.FlightGearPath = dlg.FileName;
            }
        }

        private void StartSimulation(object sender, RoutedEventArgs e)
        {
            if(!File.Exists(settings.FlightCsvPath))
            {
                MessageBox.Show("Flight file is invalid or doesn't exist, please pick a valid one.");
                return;
            }
            var serializer = new XmlSerializer(settings.GetType());
            using (var writer = XmlWriter.Create("settings.xml"))
            {
                serializer.Serialize(writer, settings);
            }
            //if the user never intended to open flight gear there's no reason to try or display a message box
            if (!string.IsNullOrEmpty(settings.FlightGearPath)) 
            {
                try
                {
                    //open flight gear
                    var startInfo = new ProcessStartInfo();
                    string fgPath = settings.FlightGearPath;
                    startInfo.FileName = fgPath;
                    int indexOfLastSlash = fgPath.LastIndexOf("\\", StringComparison.Ordinal);
                    string workingDirectory = fgPath.Substring(0, indexOfLastSlash);
                    startInfo.WorkingDirectory = workingDirectory;
                    //TODO: insert actual launch arguments 
                    startInfo.Arguments = "--generic=socket,in,10,127.0.0.1,5400,tcp,playback_small --fdm=null";
                    Process proc = Process.Start(startInfo);
                }
                catch
                {
                   MessageBox.Show("flight gear path is invalid");
                }
            }
            var mw = new MainWindow(settings.FlightCsvPath, settings.TrainingCsvPath);
            mw.Show();
            this.Close();
        }
    }
}
