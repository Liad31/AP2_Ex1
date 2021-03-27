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
        private int i = 0;
        public MainWindow(string csvFilePath, string xmlFilePath)
        {
            InitializeComponent();
            IDatabase database = new FlightDatabase(csvFilePath);
            IModel model = new FlightModel(database, 10);
            //graphsModel graphsModel = new GraphsModel(database, model);
            vm_steering = new SteeringViewModel(model);
            //vm_graphs = new GraphsPanelViewModel(graphsModel);
            controlBar.Model = model;
            vm_steering.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_Aileron")
                {
                    //stick.updateX(vm_steering.VM_Aileron);
                }
                if (e.PropertyName == "VM_Elevator")
                {
                    //stick.updateY(vm_steering.VM_Elevator);
                }
            };
            //vm_graphs.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            //{
            //    if (e.PropertyName == "VM_Line")
            //    {
            //        try
            //        {
            //            updateGraphs();
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //    if (e.PropertyName == "VM_currentProperty")
            //    {
            //        try
            //        {
            //            linearRegression.Plot.Clear();
            //            updateGraphs();
            //            linearRegression.Plot.PlotLine(vm_graphs.VM_SlopeLinearRegression, vm_graphs.VM_InterceptLinearRegression, (vm_graphs.VM_FullValuesArray.Min(),vm_graphs.VM_FullValuesArray.Max()),lineWidth: 2);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }
            //    }
            //};

            roll.DataContext = vm_steering;
            yaw.DataContext = vm_steering;
            pitch.DataContext = vm_steering;
            altitudeSlider.DataContext = vm_steering;
            altitudeText.DataContext = vm_steering;
            direction.DataContext = vm_steering;
            throttle.DataContext = vm_steering;
            rudder.DataContext = vm_steering;
            speed.DataContext = vm_steering;
            model.Start();
        }
           
        private void updateGraphs()
        {
            graph1.Plot.Clear();
            graph2.Plot.Clear();
            graph2.Plot.AddScatter(vm_graphs.VM_LineList.ToArray(), vm_graphs.VM_CorellativeValues.ToArray());
            graph1.Plot.AddScatter(vm_graphs.VM_LineList.ToArray(), vm_graphs.VM_Values.ToArray());
            linearRegression.Plot.PlotScatter(vm_graphs.VM_Values.GetRange(vm_graphs.VM_Values.Count()-vm_graphs.LPS * 30, vm_graphs.LPS * 30).ToArray(), vm_graphs.VM_CorellativeValues.GetRange(vm_graphs.VM_Values.Count() - vm_graphs.LPS * 30, vm_graphs.LPS * 30).ToArray(), System.Drawing.Color.Gray,lineWidth: 0);
            //30 seconds and not 300!!!!
        }
    }
}
