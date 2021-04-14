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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AP2_Ex1.controls
{
    /// <summary>
    /// Interaction logic for speedClock.xaml
    /// </summary>
    public partial class speedClock : UserControl
    {
        private double xCoorCenter;
        private double yCoorCenter;
        private double maxDialAngle;
        private double dialRadius;
        private double maxSpeed;
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
                    try
                    {
                        if (e.PropertyName == "VM_Speed")
                        {
                            this.Dispatcher.Invoke(() => { this.moveDiaglAccordingSpeed(vm_steering.VM_Speed); });
                        }
                    }
                    catch (Exception ex) { Console.WriteLine("the execution has stopped"); }
                };
            }
        }

        /// <summary>
        /// Max speed of airplane property
        /// </summary>
        public double MaxSpeed
        {
            get
            {
                return maxSpeed;
            }
            set
            {
                this.maxSpeed = value;
            }
        }

        /// <summary>
        /// Constructor of speed clock
        /// </summary>
        public speedClock()
        {
            InitializeComponent();
            this.xCoorCenter = dial.X1;
            this.yCoorCenter = dial.Y1;
            this.dialRadius = Math.Sqrt(Math.Pow(dial.X2 - dial.X1, 2) + Math.Pow(dial.Y2 - dial.Y1, 2));
            this.maxDialAngle = 360 - ((Math.Acos((Math.Pow(((dial.X1 - dial.X2) * 2), 2) - 2 * Math.Pow(dialRadius, 2)) / (-2 * Math.Pow(dialRadius, 2))) / Math.PI) * 180);
        }

        /// <summary>
        /// Move speed clock dial according airplane speed 
        /// </summary>
        /// <param name="speed"></param>
        public void moveDiaglAccordingSpeed(double speed)
        {
            if (speed <= 0)
            {
                moveDialAccordingAngle(0);
            }
            else if (speed >= maxSpeed)
            {
                moveDialAccordingAngle(maxDialAngle);
            }
            else
            {
                moveDialAccordingAngle(((speed * maxDialAngle) / maxSpeed));
            }
        }




        /// <summary>
        /// Move speed clock dial according angle
        /// </summary>
        /// <param name="angle"></param>
        private void moveDialAccordingAngle(double angle)
        {
            dial.X2 = dial.X1 - Math.Cos(((angle - ((180 - (360 - maxDialAngle)) / 2)) * (Math.PI)) / 180) * dialRadius;
            dial.Y2 = dial.Y1 - Math.Sin(((angle - ((180 - (360 - maxDialAngle)) / 2)) * (Math.PI)) / 180) * dialRadius;
        }
    }
}