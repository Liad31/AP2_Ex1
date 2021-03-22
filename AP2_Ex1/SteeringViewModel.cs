using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{ 
    public class SteeringViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private flightGearModel model;

        public SteeringViewModel(flightGearModel model)
        {
            this.model = model;
        }

        public double MV_Rudder
        {
            get
            {
                return model.rudder;
            }
            set
            {
                this.model.rudder = value;
                NotifyPropertyChanged("MV_Rudder");
            }
        }
        public double MV_Throttle
        {
            get
            {
                return model.throttle;
            }
            set
            {
                this.model.throttle = value;
                NotifyPropertyChanged("MV_Throttle");
            }
        }
        public double MV_Aileron
        {
            get
            {
                return model.aileron;
            }
            set
            {
                this.model.aileron = value;
                NotifyPropertyChanged("MV_Aileron");
            }
        }
        public double MV_Elevator
        {
            get
            {
                return model.elevator;
            }
            set
            {
                this.model.elevator = value;
                NotifyPropertyChanged("MV_Elevator");
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
