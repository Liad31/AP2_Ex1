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
        public List<string> Properties { get; }
        public FlightDatabase(string CSVFilePath)
        {
            this.CSVFilePath = CSVFilePath;
        }
        public List<double> getPropertyArray(string name)
        {
            //implement!!
            return null;
        }
        public string getLineString(int lineNumber)
        {
            return null;
        }


        public Dictionary<String, double> getLine(int lineNumber)
        {
            //Implement!!!!!!!!!!!!!!!!
            return null;
        }

    }
}
