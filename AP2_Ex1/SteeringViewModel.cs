﻿using System;
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
        
        public double MV_Rudder
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
        public double MV_Throttle
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
        public double MV_Aileron
        {
            get
            {
                return model.Aileron;
            }
            set
            {
                this.model.Aileron = value;
                NotifyPropertyChanged("MV_Aileron");
            }
        }
        public double MV_Elevator
        {
            get
            {
                return model.Elevator;
            }
            set
            {
                this.model.Elevator = value;
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
