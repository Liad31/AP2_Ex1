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
        private ControlBarViewModel vm_controlBar;
        //hello!
        public MainWindow(string csvFilePath, string xmlFilePath)
        {
            InitializeComponent();
            IDatabase database = new FlightDatabase(csvFilePath);
            IModel model = new FlightModel(database, 10);
            GraphsModel graphsModel = new GraphsModel(database, model);
            vm_steering = new SteeringViewModel(model);
            vm_graphs = new GraphsPanelViewModel(graphsModel);
            vm_controlBar = new ControlBarViewModel(model);
            controlBar.ViewModel = vm_controlBar;
            stick.VM_Steering = vm_steering;
            speedClock.VM_Steering = vm_steering;
            vm_graphs.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_Line")
                {
                    try
                    {
                        updateGraphs();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                if (e.PropertyName == "VM_CurrentProperty")
                {
                    try
                    {
                        linearRegression.Plot.Clear();
                        updateGraphs();
                        vm_graphs.minLinearRegressionVal = vm_graphs.VM_FullValuesArray.Min();
                        vm_graphs.maxLinearRegressionVal = vm_graphs.VM_FullValuesArray.Max();
                        linearRegression.Plot.AddLine(vm_graphs.VM_SlopeLinearRegression, vm_graphs.VM_InterceptLinearRegression,
                            (vm_graphs.minLinearRegressionVal, vm_graphs.maxLinearRegressionVal), lineWidth: 2);
                        linearRegression.Plot.AxisAuto(); 
                        this.Dispatcher.Invoke(() => { linearRegression.Render(); });
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            };
            vm_controlBar.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == "VM_IsPaused")
                {
                    bool isPaused = vm_controlBar.VM_IsPaused;
                    if (isPaused)
                    {
                        graph1.IsEnabled = true;
                        graph2.IsEnabled = true;
                        linearRegression.IsEnabled = true;
                    }
                    else
                    {
                        graph1.IsEnabled = false;
                        graph2.IsEnabled = false;
                        linearRegression.IsEnabled = false;
                    }
                }
            };

            roll.DataContext = vm_steering;
            yaw.DataContext = vm_steering;
            pitch.DataContext = vm_steering;
            altitudeSlider.DataContext = vm_steering;
            altitudeText.DataContext = vm_steering;
            direction.DataContext = vm_steering;
            throttle.DataContext = vm_steering;
            rudder.DataContext = vm_steering;
            speed.DataContext = vm_steering;
            titleGraph2.DataContext = vm_graphs;
            properties.DataContext = vm_graphs;
            model.Start();
        }

        private void updateGraphs()
        {
            if (vm_graphs.VM_CurrentProperty != null)
            {
                try
                {
                    graph1.Plot.Clear();
                    graph2.Plot.Clear();
                    int len = vm_graphs.VM_Line;
                    double[] arr = new double[len];
                    double[] arr1 = new double[len];
                    double[] arr2 = new double[len];
                    vm_graphs.VM_LineList.GetRange(0, vm_graphs.VM_Line).ToArray().CopyTo(arr, 0);
                    vm_graphs.VM_FullValuesArray.GetRange(0, vm_graphs.VM_Line).ToArray().CopyTo(arr1, 0);
                    vm_graphs.VM_FullCorellativeValuesArray.GetRange(0, vm_graphs.VM_Line).ToArray().CopyTo(arr2, 0);
                    graph2.Plot.AddScatter(arr, arr2);
                    graph1.Plot.AddScatter(arr, arr1);
                    graph1.Plot.AxisAuto();
                    graph2.Plot.AxisAuto();
                    this.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            graph1.Render();
                        }
                        catch (Exception e) { }
                    });
                    this.Dispatcher.Invoke(() =>
                    {
                        try
                        {
                            graph2.Render();
                        }
                        catch (Exception e) { }
                    });

                    linearRegression.Plot.Clear();
                    linearRegression.Plot.AddLine(vm_graphs.VM_SlopeLinearRegression, vm_graphs.VM_InterceptLinearRegression,
                        (vm_graphs.minLinearRegressionVal, vm_graphs.maxLinearRegressionVal), lineWidth: 2);
                    linearRegression.Plot.AddScatter(vm_graphs.VM_Values.ToArray(),
                     vm_graphs.VM_CorellativeValues.ToArray(), System.Drawing.Color.Gray, lineWidth: 0);
                    //printing the last 30 seconds samples
                    linearRegression.Plot.AddScatter(vm_graphs.VM_Values.GetRange(Math.Max(vm_graphs.VM_Values.Count() - vm_graphs.LPS * 30, 0), Math.Min(vm_graphs.LPS * 30, vm_graphs.VM_Values.Count())).ToArray(),
                     vm_graphs.VM_CorellativeValues.GetRange(Math.Max(vm_graphs.VM_Values.Count() - vm_graphs.LPS * 30, 0), Math.Min(vm_graphs.LPS * 30, vm_graphs.VM_Values.Count())).ToArray(), System.Drawing.Color.Red, lineWidth: 0);
                    linearRegression.Plot.AxisAuto();
                    this.Dispatcher.Invoke(() => 
                    {
                        try
                        {
                            linearRegression.Render();
                        }
                        catch (Exception e) { }
                    });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private void Properties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                vm_graphs.switchGraphs(properties.SelectedItem.ToString());
            }
            catch (Exception ex) { }
        }
    }
}
