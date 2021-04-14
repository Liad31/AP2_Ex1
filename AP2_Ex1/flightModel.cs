using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace AP2_Ex1
{
    public class FlightModel : IModel
    {
        private bool stop; //for stopping the model
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
        private string currentTime;
        private bool isPaused = true;
        private List<double> exceptions;
        public string dllPath { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Dictionary<String, double> LastLine { get; }

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

        public List<double> Exceptions
        {
            get
            {
                return exceptions;
            }
            set
            {
                exceptions = value;
                NotifyPropertyChanged("Exceptions");
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

        public string CurrentTimeString
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                NotifyPropertyChanged("CurrentTime");
            }
        }

        public bool IsPaused {
            get
            {
                return isPaused;
            }
            set
            {
                isPaused = value;
                NotifyPropertyChanged("IsPaused");
            }
        }

        public double CurrentTime { get; set; }
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

        //Flight properties we will show on screen
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
                return direction;
            }
            set
            {
                direction = value;
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

        public double Roll
        {
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
                Client client = new Client("127.0.0.1", 5400);
                while (!stop)
                {
                    if (!IsPaused && CurrentLine < lineCount - 1)
                    {
                        CurrentLine++;
                    }
                    //project the flight on flight gear
                    client.sendString(database.getLineString(CurrentLine) + "\n");
                    dic = database.getLine(CurrentLine);

                    //update all the properties
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
                    dic.TryGetValue("heading-deg", out temp);
                    Direction = temp;
                    CurrentTimeString = (TimeSpan.FromSeconds(CurrentLine / LPS)).ToString(@"mm\:ss"); ;

                    //this adjust the video speed
                    Thread.Sleep((int)(1000 / (LPS * SpeedMultiplier)));
                }

                if (client != null)
                {
                    client.close();
                }
            }).Start();
        }

        public void Stop()
        {
            stop = true;
        }

        public void changeDLL(string path)
        {
            try
            {
                dllPath = path;
                NotifyPropertyChanged("DLL");
                
            }
            catch
            {
                MessageBox.Show("the dll doesnt fit to the application");
            }
        }

    }
}