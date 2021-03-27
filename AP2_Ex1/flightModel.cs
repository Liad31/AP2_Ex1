using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class FlightModel : IModel
    {
        private bool stop;
        private IDatabase database;
        private int currentLine;
        private int lineCount;
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<String, double> LastLine { get; }
        //please implement the set functions so they will invoke NotifyPropertyChanged!!!!
        public int LineCount
        {
            get
            {
                return lineCount;
            }
            private set
            {
                lineCount = value;
                NotifyPropertyChanged("LineCount");
            }
        }
        public int CurrentLine
        {
            get { return currentLine; }
            set
            {
                currentLine = value;
                NotifyPropertyChanged("CurrentLine");
            }

        }
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
        public int LPS { get; private set; }
        public FlightModel(IDatabase database, int lps)
        {
            this.database = database;
            LineCount = database.numOfLines();
            LPS = lps;
            //init propertyByColumn
        }
        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        public void Start()
        {
            new Thread(delegate ()
            {

                stop = false;
                while (!stop)
                {
                    if (!IsPaused)
                    {
                        CurrentLine++;
                    }
                    Thread.Sleep(1000/LPS);
                }
            }).Start();
        }

        public void Stop()
        {
            stop = true;
        }
    }
}
