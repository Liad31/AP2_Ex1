using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    public class flightGearModel
    {
        private string dataFile;
        private string xmlFile;

        public double rudder { get; set; }
        public double throttle { get; set; }
        public double aileron { get; set; }
        public double elevator { get; set; }
        public double altitude { get; set; }
        public double speed { get; set; }
        public double direction { get; set; }
        public double yaw { get; set; }
        public double roll { get; set; }
        public double pitch { get; set; }
        public flightGearModel(string dataFile, string xmlFile)
        {
            this.dataFile = dataFile;
            this.xmlFile = xmlFile;
        }
      
    }
}
