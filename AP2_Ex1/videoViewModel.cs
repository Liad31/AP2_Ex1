using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace AP2_Ex1
{
    public class videoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private flightGearModel model;
        public videoViewModel(flightGearModel model)
        {
            this.model = model;
        }
    }
}
