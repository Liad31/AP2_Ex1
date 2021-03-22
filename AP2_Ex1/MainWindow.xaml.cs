using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace AP2_Ex1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SteeringViewModel vm_steering;
        private videoViewModel vm_video;
        private dataViewModel vm_data;
        public MainWindow(string csvFilePath, string xmlFilePath)
        {
            InitializeComponent();
            flightGearModel model = new flightGearModel(csvFilePath, xmlFilePath);
            this.vm_video = new videoViewModel(model);
            this.vm_steering = new SteeringViewModel(model);
            this.vm_data = new dataViewModel(model);

            vm_steering.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "MV_Aileron")
                {
                    //stick.updateX(vm_steering.MV_Aileron);
                }
                if (e.PropertyName == "MV_Elevator")
                {
                    //stick.updateY(vm_steering.MV_Elevator);
                }
          
            };
        }

    }
}
