using System.Collections.Generic;
using System.ComponentModel;
//placeholderClass
namespace AP2_Ex1
{
    public class ModelImplementation :IModel
    {
        public ModelImplementation(IDatabase database)
        {
            
        }
        event PropertyChangedEventHandler INotifyPropertyChanged.PropertyChanged
        {
            add => throw new System.NotImplementedException();
            remove => throw new System.NotImplementedException();
        }

        public Dictionary<string, double> LastLine { get; }
        public int LineCount { get; }
        public int CurrentLine { get; set; }
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

        event PropertyChangedEventHandler IModel.PropertyChanged
        {
            add => throw new System.NotImplementedException();
            remove => throw new System.NotImplementedException();
        }
    }
}