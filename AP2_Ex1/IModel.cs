using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public interface IModel : INotifyPropertyChanged
    {
        /// <summary>
        /// starting the simulation in a new thread
        /// </summary>
        void Start();

        /// <summary>
        /// stopping the simulation
        /// </summary>
        void Stop();

        Dictionary<String, double> LastLine { get; }
        
        /// <summary>
        /// how many lines does the csv file has
        /// </summary>
        int LineCount{get;}

        /// <summary>
        /// current line we are reading
        /// </summary>
        int CurrentLine { get; set; }

        /// <summary>
        /// A string repesenting the current time (mm:ss)
        /// </summary>
        string CurrentTimeString { get; set; }

        /// <summary>
        /// a number representing the current time (in seconds)
        /// </summary>
        double CurrentTime { get; set; }

        /// <summary>
        /// speed multiplier of the video
        /// </summary>
        double SpeedMultiplier { get; set; }

        /// <summary>
        /// is the video paused
        /// </summary>
        bool IsPaused { get; set; }
        
        //Those are the flight properties we want to show
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

        /// <summary>
        /// List of the lines there is a flight anomaly.
        /// </summary>
        List<double> Exceptions { get; set; }

        /// <summary>
        /// How many Lines Per Second should the Model read.
        /// </summary>
        int LPS { get; }
        string dllPath { get; set; }

        void changeDLL(string path);
    }
}



