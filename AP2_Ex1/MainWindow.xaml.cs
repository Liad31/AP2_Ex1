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
        public MainWindow(string csvFilePath, string xmlFilePath)
        {
            InitializeComponent();
            var database = new FlightDatabase(csvFilePath);
            var model = new FlightModel(database);
            vm_steering = new SteeringViewModel(model);
            vm_steering.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "VM_Aileron")
                {
                    stick.updateX(vm_steering.VM_Aileron);
                }
                if (e.PropertyName == "MVM_Elevator")
                {
                    stick.updateY(vm_steering.VM_Elevator);
                }
          
            };
        }

    }
}
