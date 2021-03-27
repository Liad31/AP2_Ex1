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
        public List<string> VM_Properties
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
        public List<double> VM_Values
        {
            get
            {
                return model.values.GetRange(0, VM_Line);
            }
        }
        public List<double> VM_FullValuesArray
        {
            get
            {
                return model.values;
            }
        }
        public List<double> VM_CorellativeValues
        {
            get
            {
                return model.correlativeValues.GetRange(0, VM_Line);
            }
        }
        public List<double> VM_FullCorellativeValuesArray
        {
            get
            {
                return model.correlativeValues;
            }
        }
        public List<double> VM_LineList
        {
            get
            {
                return model.LineList.GetRange(0, VM_Line);
            }
        }
        public string VM_CurrentProperty
        {
            get
            {
                return model.currentProperty;
            }
        }
        public string VM_MostCorellativeProperty
        {
            get
            {
                return model.mostCorelative[VM_CurrentProperty].name;
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
        public void switchGraphs(string propName)
        {
            model.currentProperty = propName;
            model.switchGraphs();
        }
        public double VM_SlopeLinearRegression
        {
            get
            {
                return model.mostCorelative[VM_CurrentProperty].slopeOfLinearRegression;
            }
        }
        public double VM_InterceptLinearRegression
        {
            get
            {
                return model.mostCorelative[VM_CurrentProperty].yInterceptLinearRegression;
            }
        }
        public int LPS
        {
            get
            {
                return model.LPS;
            }
        }
    }
}
