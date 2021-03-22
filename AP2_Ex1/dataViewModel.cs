using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AP2_Ex1
{
    public class dataViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private double mv_altitude;// making them all properties and not fields
        private double mv_direction;
        private double mv_yaw;
        private double mv_roll;
        private double mv_pitch;
        private flightGearModel model;

        public dataViewModel(flightGearModel model)
        {
            this.model = model;
        }
        public double MV_Altitude
        {
            get
            {
                return model.altitude;
            }
            set
            {
                this.model.altitude = value;
                NotifyPropertyChanged("MV_Altitude");
            }
        }
        public double MV_Speed
        {
            get
            {
                return model.speed;
            }
            set
            {
                this.model.speed = value;
                NotifyPropertyChanged("MV_Speed");
            }
        }
        public double MV_Direction
        {
            get
            {
                return model.direction;
            }
            set
            {
                this.model.direction = value;
                NotifyPropertyChanged("MV_Direction");
            }
        }
        public double MV_Yaw
        {
            get
            {
                return model.yaw;
            }
            set
            {
                this.model.yaw = value;
                NotifyPropertyChanged("MV_Yaw");
            }
        }
        public double MV_Roll
        {
            get
            {
                return model.roll;
            }
            set
            {
                this.model.roll = value;
                NotifyPropertyChanged("MV_Roll");
            }
        }
        public double MV_Pitch
        {
            get
            {
                return model.pitch;
            }
            set
            {
                this.model.pitch = value;
                NotifyPropertyChanged("MV_Pitch");
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
