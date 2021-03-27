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
            //var graphsModel = new GraphsModel(database, model);
            vm_steering = new SteeringViewModel(model);
            //vm_graphs = new GraphsPanelViewModel(graphsModel);
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
          
        }
           
        private void updateGraphs()
        {
            graph1.Plot.Clear();
            graph2.Plot.Clear();
            graph2.Plot.AddScatter(vm_graphs.VM_LineList.ToArray(), vm_graphs.VM_CorellativeValues.ToArray());
            graph1.Plot.AddScatter(vm_graphs.VM_LineList.ToArray(), vm_graphs.VM_Values.ToArray());
            linearRegression.Plot.PlotScatter(vm_graphs.VM_Values.GetRange(vm_graphs.VM_Values.Count()-300, 300).ToArray(), vm_graphs.VM_CorellativeValues.GetRange(vm_graphs.VM_Values.Count() - 300, 300).ToArray(), System.Drawing.Color.Gray,lineWidth: 0);
            //30 seconds and not 300!!!!
        }
    }
}
