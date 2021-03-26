using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    class FlightDatabase : IDatabase
    {
        private string CSVFilePath;
        private Dictionary<string, double[]> data;
        public FlightDatabase(string CSVFilePath)
        {
            this.CSVFilePath = CSVFilePath;
        }
        public  double[] getPropertyArray(string property)
        {
            //implement!!
            return null;
        }



        public Dictionary<String, double> getLine(int lineNumber)
        {
            //Implement!!!!!!!!!!!!!!!!
            return null;
        }

    }
}
