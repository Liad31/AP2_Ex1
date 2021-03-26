using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class GraphsPanelViewModel : INotifyPropertyChanged
    {
        GraphsModel model;
        public event PropertyChangedEventHandler PropertyChanged;

        public GraphsPanelViewModel(GraphsModel model) {
            this.model = model;
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                NotifyPropertyChanged("VM_" + e.PropertyName);
            };
        }
        public List<string> Properties
        {
            get
            {
                return model.database.Properties;
            }
        }
        public int VM_Line{
            get
            {
                return model.Line;
            }
        }
        public List<double> values
        {
            get
            {
                return model.values.GetRange(0, VM_Line);
            }
        }
        public List<double> LineList
        {
            get
            {
                return model.LineList.GetRange(0, VM_Line);
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
