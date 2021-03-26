using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class GraphsModel
    {
        public Dictionary<string, string> mostCorelative { get; }
        public IDatabase database { get; }
        public GraphsModel(IDatabase database)
        {
            this.database = database;
            initCorelatives();
        }
        private void initCorelatives()
        {
            foreach (var property in database.properties)
            {
                double max = -1;
                mostCorelative.Add(property, null);
                double[] arr1 = getPropertyArray(property);
                foreach (var otherProperty in database.properties)
                {
                    if (property != otherProperty)
                    {
                        double[] arr2 = getPropertyArray(otherProperty);
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

        private double getPearson(double [] arr1, Double [] arr2)
        {
            if (arr1.Length != arr2.Length)
                throw new ArgumentException("values must be the same length");

            var avg1 = arr1.Average();
            var avg2 = arr2.Average();

            var sum1 = arr1.Zip(arr2, (x1, y1) => (x1 - avg1) * (y1 - avg2)).Sum();

            var sumSqr1 = arr1.Sum(x => Math.Pow((x - avg1), 2.0));
            var sumSqr2 = arr2.Sum(y => Math.Pow((y - avg2), 2.0));

            var result = sum1 / Math.Sqrt(sumSqr1 * sumSqr2);

            return result;
        }
    }
}
