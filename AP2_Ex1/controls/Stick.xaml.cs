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
using System.ComponentModel;

namespace AP2_Ex1.controls
{
    /// <summary>
    /// Interaction logic for Stick.xaml
    /// </summary>
    public partial class Stick : UserControl
    {
        private SteeringViewModel vm_steering;
        public SteeringViewModel VM_Steering
        {
            get
            {
                return vm_steering;
            }
            set
            {
                vm_steering = value;
                vm_steering.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
                {
                    if (e.PropertyName == "VM_Aileron")
                    {
                        this.Dispatcher.Invoke(() => { updateX(vm_steering.VM_Aileron); });
                    }
                    if (e.PropertyName == "VM_Elevator")
                    {
                        this.Dispatcher.Invoke(() => { updateY(vm_steering.VM_Aileron); });
                    }
                };
            }
        }
        public Stick()
        {
            InitializeComponent();
        }

        public void updateX(double newX)
        {
            //positioning the insider stick at the middle of its space
            Thickness margin = stick.Margin;
            margin.Left = (space.Margin.Left + space.Width / 2.0 - stick.Width / 2 + newX * space.Width / 2.0);
            stick.Margin = margin;
        }
        public void updateY(double newY)
        {
            //positioning the insider stick at the middle of its space
            Thickness margin = stick.Margin;
            margin.Top = (space.Margin.Top + space.Height / 2.0 - stick.Width / 2 + newY * space.Height / 2.0);
            stick.Margin = margin;
        }


    }
}
