﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class ControlBarViewModel : INotifyPropertyChanged
    {
        IModel model;
        public event PropertyChangedEventHandler PropertyChanged;
        public ControlBarViewModel(IModel model)
        {
            this.model = model;
            model.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public int VM_LineCount
        {
            get
            {
                return model.LineCount;
            }
        }
        public int VM_CurrentLine
        {
            get
            {
                return model.CurrentLine;
            }
            set
            {
                this.model.CurrentLine = value;
            }

        }
        public bool VM_IsPaused
        {
            get
            {
                return model.IsPaused;
            }
            set
            {
                this.model.IsPaused = value;
            }
        }
        public double VM_SpeedMultiplier
        {
            get
            {
                return model.SpeedMultiplier;
            }
            set
            {
                this.model.SpeedMultiplier = value;
            }
        }
       

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        

    }
}