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
        private GraphsPanelViewModel vm_graphs;
        public MainWindow(string csvFilePath, string xmlFilePath)
        {
            InitializeComponent();
            var database = new FlightDatabase(csvFilePath);
            var model = new FlightModel(database);
            var graphsModel = new GraphsModel(database, model);
            vm_steering = new SteeringViewModel(model);
            vm_graphs = new GraphsPanelViewModel(graphsModel);
            vm_steering.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_Aileron")
                {
                    stick.updateX(vm_steering.VM_Aileron);
                }
                if (e.PropertyName == "VM_Elevator")
                {
                    stick.updateY(vm_steering.VM_Elevator);
                }
            };
            vm_graphs.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_Line")
                {
                    p.Plot.Clear();
                    try
                    {
                        p.Plot.AddScatter(vm_graphs.LineList.ToArray(), vm_graphs.values.ToArray());
                    } catch(Exception ex) {}
                }
            };
          
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
