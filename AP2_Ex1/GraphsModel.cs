using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class GraphsModel : INotifyPropertyChanged
    {
        public Dictionary<string, string> mostCorelative { get; }
        public IDatabase database { get; }
        public string currentProperty { get; set; }
        public List<double> values { get; private set; }
        public List<double> correlativeValues { get; private set; }
        public int Line { get; private set; }
        public event PropertyChangedEventHandler PropertyChanged;
        public List<double> LineList { get; private set; }

        public GraphsModel(IDatabase database, IModel mainModel)
        {
            this.database = database;
            for (int i = 1; i < mainModel.LineCount; ++i)
            {
                LineList.Add(i);
            }
            mainModel.PropertyChanged += delegate(Object sender, PropertyChangedEventArgs e) {
                if (e.PropertyName == "CurrentLine")
                {
                    Line++;
                    NotifyPropertyChanged("Line");
                }
            };
            initCorelatives();
        }
        private void initCorelatives()
        {
            foreach (var property in database.Properties)
            {
                double max = -1;
                mostCorelative.Add(property, null);
                List<double> arr1 = database.getPropertyArray(property);
                foreach (var otherProperty in database.Properties)
                {
                    if (property != otherProperty)
                    {
                        List<double> arr2 =database.getPropertyArray(otherProperty);
                        double tempPearson = getPearson(arr1, arr2);
                        if (tempPearson > max)
                        {
                            max = tempPearson;
                            mostCorelative[property] = otherProperty;
                        }

                    }
                }
            }
        }

        private double getPearson(List<double> arr1, List<double> arr2)
        {
            if (arr1.Count() != arr2.Count())
                throw new ArgumentException("values must be the same length");

            var avg1 = arr1.Average();
            var avg2 = arr2.Average();

            var sum1 = arr1.Zip(arr2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = arr1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = arr2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
