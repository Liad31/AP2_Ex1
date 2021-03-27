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
        private double roll;
        private double pitch;
        private double yaw;
        private double aileron;
        private double elevator;
        private double throttle;
        private double rudder;
        private double altimeter;
        private double airspeed;
        private double direction;
        private double speedMultiplier;
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
        public bool IsPaused{ get; set; }
        public double Rudder
        {
            get
            {
                return rudder;
            }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }
        public double Throttle
        {
            get
            {
                return throttle;
            }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        public double Aileron
        {
            get
            {
                return aileron;
            }
            set
            {
                aileron = value;
                NotifyPropertyChanged("Aileron");
            }
        }
        public double Elevator
        {
            get
            {
                return elevator;
            }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }
        public double Altitude
        {
            get
            {
                return altimeter;
            }
            set
            {
                altimeter = value;
                NotifyPropertyChanged("Altitude");
            }
        }
        public double Speed
        {
            get
            {
                return airspeed;
            }
            set
            {
                airspeed = value;
                NotifyPropertyChanged("Speed");
            }
        }
        public double Direction
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
                NotifyPropertyChanged("Direction");
            }
        }
        public double Yaw
        {
            get
            {
                return yaw;
            }
            set
            {
                yaw = value;
                NotifyPropertyChanged("Yaw");
            }
        }
        public double Roll {
            get
            {
                return roll;
            }
            set
            {
                roll = value;
                NotifyPropertyChanged("Roll");
            }
        }
        public double Pitch
        {
            get
            {
                return pitch;
            }
            set
            {
                pitch = value;
                NotifyPropertyChanged("Pitch");
            }
        }
        public double SpeedMultiplier
        {
            get { return speedMultiplier; }
            set
            {
                speedMultiplier = value;
                NotifyPropertyChanged("SpeedMultiplier");
            }
        }

        public int LPS { get; private set; }
        public FlightModel(IDatabase database, int lps)
        {
            this.database = database;
            LineCount = database.numOfLines();
            SpeedMultiplier = 1;
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
                Dictionary<string, double> dic = database.getLine(CurrentLine);
                while (!stop)
                {
                    if (!IsPaused && CurrentLine < lineCount - 1)
                    {
                        CurrentLine++;
                    }
                    dic = database.getLine(CurrentLine);
                    double temp;
                    dic.TryGetValue("roll-deg", out temp);
                    Roll = temp;
                    dic.TryGetValue("pitch-deg", out temp);
                    Pitch = temp;
                    dic.TryGetValue("side-slip-deg", out temp);
                    Yaw = temp;
                    dic.TryGetValue("aileron", out temp);
                    Aileron = temp;
                    dic.TryGetValue("elevator", out temp);
                    Elevator = temp;
                    dic.TryGetValue("rudder", out temp);
                    Rudder = temp;
                    dic.TryGetValue("throttle", out temp);
                    Throttle = temp;
                    dic.TryGetValue("airspeed-kt", out temp);
                    Speed = temp;
                    dic.TryGetValue("altitude-ft", out temp);
                    Altitude = temp;
                    //add the "direction"!!!

                    CurrentTime = CurrentLine / LPS;
                    Thread.Sleep((int) (1000/(LPS * SpeedMultiplier)));
                }
            }).Start();
        }

        public void Stop()
        {
            stop = true;
        }
    }
}
