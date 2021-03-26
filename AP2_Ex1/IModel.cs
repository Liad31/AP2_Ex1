﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
     public interface IModel : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
        Dictionary<String, double> LastLine { get; }
        int LineCount{get;}
        int CurrentLine { get; set; }
        double CurrentTime { get; set; }
        double SpeedMultiplier { get; set; }
        bool IsPaused { get; set; }
        
        double Rudder { get; set; }
        double Throttle { get; set; }
        double Aileron { get; set; }
        double Elevator { get; set; }
        double Altitude { get; set; }
        double Speed { get; set; }
        double Direction { get; set; }
        double Yaw { get; set; }
        double Roll { get; set; }
        double Pitch { get; set; }
    }
}