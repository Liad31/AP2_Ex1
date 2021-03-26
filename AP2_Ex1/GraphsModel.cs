using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace AP2_Ex1
{
    public class corellativeProperty
    {
        public string name { get; set; }
        public double slopeOfLinearRegression { get; set; }
        public double yInterceptLinearRegression { get; set; }
    }
    public class GraphsModel : INotifyPropertyChanged
    {
        public Dictionary<string, corellativeProperty> mostCorelative { get; }
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
            foreach (string property in database.Properties)
            {
                double max = -1;
                mostCorelative.Add(property, null);
                var arr1 = database.getPropertyArray(property) as List<double>;
                foreach (string otherProperty in database.Properties)
                {
                    if (property != otherProperty)
                    {
                        var arr2 = database.getPropertyArray(otherProperty) as List<double>;
                        var tempPearson = getPearson(arr1, arr2);
                        if (tempPearson > max)
                        {
                            max = tempPearson;
                            mostCorelative[property].name = otherProperty;
                        }
                    }
                }
                //initializg the linear regression of each 2 corelative variables
                values = database.getPropertyArray(property);
                correlativeValues = database.getPropertyArray(mostCorelative[property].name);
                double slope, intercept;

                LinearRegression(values.ToArray(), correlativeValues.ToArray(), out intercept, out slope);
                mostCorelative[property].yInterceptLinearRegression = intercept;
                mostCorelative[property].slopeOfLinearRegression = slope;
            }
        }

        public static void LinearRegression(
            double[] xVals,
            double[] yVals,
            out double yIntercept,
            out double slope)
        {
            if (xVals.Length != yVals.Length)
            {
                throw new Exception("Input values should be with the same length.");
            }

            double sumOfX = 0;
            double sumOfY = 0;
            double sumOfXSq = 0;
            double sumOfYSq = 0;
            double sumCodeviates = 0;

            for (var i = 0; i < xVals.Length; i++)
            {
                var x = xVals[i];
                var y = yVals[i];
                sumCodeviates += x * y;
                sumOfX += x;
                sumOfY += y;
                sumOfXSq += x * x;
                sumOfYSq += y * y;
            }

            var count = xVals.Length;
            var ssX = sumOfXSq - ((sumOfX * sumOfX) / count);
            var ssY = sumOfYSq - ((sumOfY * sumOfY) / count);

            var rNumerator = (count * sumCodeviates) - (sumOfX * sumOfY);
            var rDenom = (count * sumOfXSq - (sumOfX * sumOfX)) * (count * sumOfYSq - (sumOfY * sumOfY));
            var sCo = sumCodeviates - ((sumOfX * sumOfY) / count);

            var meanX = sumOfX / count;
            var meanY = sumOfY / count;
            var dblR = rNumerator / Math.Sqrt(rDenom);

            yIntercept = meanY - ((sCo / ssX) * meanX);
            slope = sCo / ssX;
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
        public void switchGraphs()
        {
            values = database.getPropertyArray(currentProperty);
            correlativeValues = database.getPropertyArray(mostCorelative[currentProperty].name);
            NotifyPropertyChanged("currentProperty");
        }
    }
}
