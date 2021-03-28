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

namespace AP2_Ex1.controls
{
    /// <summary>
    /// Interaction logic for Compass.xaml
    /// </summary>
    public partial class Compass : UserControl
    {
        private double xCoorCenter;
        private double yCoorCenter;
        private double dialRadius;

        public Compass()
        {
            InitializeComponent();
            this.xCoorCenter = dial.X1;
            this.yCoorCenter = dial.Y1;
            this.dialRadius = Math.Sqrt(Math.Pow(dial.X2 - dial.X1, 2) + Math.Pow(dial.Y2 - dial.Y1, 2));
        }

        public void moveDialAccordingAngle(double angle)
        {
            dial.X2 = dial.X1 + Math.Cos((angle * (Math.PI)) / 180) * dialRadius;
            dial.Y2 = dial.Y1 - Math.Sin((angle * (Math.PI)) / 180) * dialRadius;
        }
    }
}
