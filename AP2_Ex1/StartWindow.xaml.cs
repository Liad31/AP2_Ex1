using Microsoft.Win32;
using System;
using System.Collections.Generic;
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

namespace AP2_Ex1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        private string CSVFile = "";
        private string XMLFile = "";
        public StartWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                this.CSVFile = filename;
                this.dataFileBox.Text = filename;
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dlg = new OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                // Save document
                string filename = dlg.FileName;
                this.XMLFile = filename;
                this.XMLFileBox.Text = filename;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var mw = new MainWindow(CSVFile, XMLFile);
            mw.Show();
            this.Close();
        }
    }
}
