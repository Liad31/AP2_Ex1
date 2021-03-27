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
        private IModel model;

        public SteeringViewModel(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        
        public double VM_Rudder
        {
            get
            {
                return model.Rudder;
            }
            set
            {
                this.model.Rudder = value;
                NotifyPropertyChanged("MV_Rudder");
            }
        }
        public double VM_Throttle
        {
            get
            {
                return model.Throttle;
            }
            set
            {
                this.model.Throttle = value;
                NotifyPropertyChanged("MV_Throttle");
            }
        }
        public double VM_Aileron
        {
            get
            {
                return model.Aileron;
            }
            set
            {
                this.model.Aileron = value;
            }
        }
        public double VM_Elevator
        {
            get
            {
                return model.Elevator;
            }
            set
            {
                this.model.Elevator = value;
            }
        }
        public double VM_Altitude
        {
            get
            {
                return model.Altitude;
            }
            set
            {
                this.model.Altitude = value;
            }
        }
        public double VM_Speed
        {
            get
            {
                return model.Speed;
            }
            set
            {
                this.model.Speed = value;
            }
        }
        public double VM_Direction
        {
            get
            {
                return model.Direction;
            }
            set
            {
                this.model.Direction = value;
            }
        }
        public double VM_Yaw
        {
            get
            {
                return model.Yaw;
            }
            set
            {
                this.model.Yaw = value;
            }
        }
        public double VM_Roll
        {
            get
            {
                return model.Roll;
            }
            set
            {
                this.model.Roll = value;
            }
        }
        public double VM_Pitch
        {
            get
            {
                return model.Pitch;
            }
            set
            {
                this.model.Pitch = value;
            }
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
