using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class FlightModel : IModel
    {
        private IDatabase database;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<String, double> LastLine { get; }
        //please implement the set functions so they will invoke NotifyPropertyChanged!!!!
        public int LineCount { get; }
        public int CurrentLine{ get; set; }
        public double CurrentTime { get; set; }
        public double SpeedMultiplier { get; set; }
        public bool IsPaused { get; set; }
        public double Rudder { get; set; }
        public double Throttle { get; set; }
        public double Aileron { get; set; }
        public double Elevator { get; set; }
        public double Altitude { get; set; }
        public double Speed { get; set; }
        public double Direction { get; set; }
        public double Yaw { get; set; }
        public double Roll { get; set; }
        public double Pitch { get; set; }
        public FlightModel(IDatabase database)
        {
            this.database = database;
            //init propertyByColumn
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
