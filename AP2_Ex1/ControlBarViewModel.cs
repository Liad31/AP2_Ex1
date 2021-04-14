using System;
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
            model.PropertyChanged += delegate (object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
            VM_IsPaused = true;
        }

        /// <summary>
        /// how many lines does we have to read (actually index of last one, starting from 0, this is why -1)
        /// </summary>
        public int VM_LineCount
        {
            get
            {
                return model.LineCount - 1;
            }
        }

        public List<double> VM_Exceptions
        {
            get
            {
                return model.Exceptions;
            }
            set
            {
                this.model.Exceptions = value;
            }
        }

        /// <summary>
        /// number of current line we are reading
        /// </summary>
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

        /// <summary>
        /// Is the vidow paused
        /// </summary>
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

        /// <summary>
        /// Video's speed multiplier
        /// </summary>
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

        /// <summary>
        /// How many Lines Per Second do we read.
        /// </summary>
        public int VM_LPS
        {
            get
            {
                return model.LPS;
            }
        }

        public string VM_CurrentTime
        {
            get
            {
                return model.CurrentTimeString;
            }
        }


        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        /// <summary>
        /// stops the model
        /// </summary>
        public void Stop()
        {
            model.Stop();
        }
        public string VM_DLL
        {
            get
            {
                return model.dllPath;
            }
        }
    }
}

}


