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
        private IModel model;

        public dataViewModel(IModel model)
        {
            this.model = model;
            
        }
        public double MV_Altitude
        {
            get
            {
                return model.Altitude;
            }
            set
            {
                this.model.Altitude = value;
                NotifyPropertyChanged("MV_Altitude");
            }
        }
        public double MV_Speed
        {
            get
            {
                return model.Speed;
            }
            set
            {
                this.model.Speed = value;
                NotifyPropertyChanged("MV_Speed");
            }
        }
        public double MV_Direction
        {
            get
            {
                return model.Direction;
            }
            set
            {
                this.model.Direction = value;
                NotifyPropertyChanged("MV_Direction");
            }
        }
        public double MV_Yaw
        {
            get
            {
                return model.Yaw;
            }
            set
            {
                this.model.Yaw = value;
                NotifyPropertyChanged("MV_Yaw");
            }
        }
        public double MV_Roll
        {
            get
            {
                return model.Roll;
            }
            set
            {
                this.model.Roll = value;
                NotifyPropertyChanged("MV_Roll");
            }
        }
        public double MV_Pitch
        {
            get
            {
                return model.Pitch;
            }
            set
            {
                this.model.Pitch = value;
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
