using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP2_Ex1
{
    class FlightDatabase : IDatabase
    {
        private ArrayList data;
        private ArrayList lines;
        private List<string> keys;
        public FlightDatabase(string CSVFilePath)
        {
            StreamReader reader = new StreamReader(File.OpenRead(CSVFilePath));
            data = new ArrayList();
            lines = new ArrayList();
            while (!reader.EndOfStream)
            {
                Dictionary<String, Double> d = new Dictionary<string, double>();
                String line = reader.ReadLine();
                lines.Add(line);
                String[] values = line.Split(',');
                d.Add("aileron", Convert.ToDouble(values[0]));
                d.Add("elevator", Convert.ToDouble(values[1]));
                d.Add("rudder", Convert.ToDouble(values[2]));
                d.Add("flaps", Convert.ToDouble(values[3]));
                d.Add("slats", Convert.ToDouble(values[4]));
                d.Add("speedbrake", Convert.ToDouble(values[5]));
                d.Add("throttle", Convert.ToDouble(values[6]));
                //d.Add("throttle", Convert.ToDouble(values[7]));
                d.Add("engine-pump", Convert.ToDouble(values[8]));
                //d.Add("engine-pump", Convert.ToDouble(values[9]));
                d.Add("electric-pump", Convert.ToDouble(values[10]));
                //d.Add("electric-pump", Convert.ToDouble(values[11]));
                d.Add("external-power", Convert.ToDouble(values[12]));
                d.Add("APU-generator", Convert.ToDouble(values[13]));
                d.Add("latitude-deg", Convert.ToDouble(values[14]));
                d.Add("longitude-deg", Convert.ToDouble(values[15]));
                d.Add("altitude-ft", Convert.ToDouble(values[16]));
                d.Add("roll-deg", Convert.ToDouble(values[17]));
                d.Add("pitch-deg", Convert.ToDouble(values[18]));
                d.Add("heading-deg", Convert.ToDouble(values[19]));
                d.Add("side-slip-deg", Convert.ToDouble(values[20]));
                d.Add("airspeed-kt", Convert.ToDouble(values[21]));
                d.Add("glideslope", Convert.ToDouble(values[22]));
                d.Add("vertical-speed-fps", Convert.ToDouble(values[23]));
                d.Add("airspeed-indicator_indicated-speed-kt", Convert.ToDouble(values[24]));
                d.Add("altimeter_indicated-altitude-ft", Convert.ToDouble(values[25]));
                d.Add("altimeter_pressure-alt-ft", Convert.ToDouble(values[26]));
                d.Add("attitude-indicator_indicated-pitch-deg", Convert.ToDouble(values[27]));
                d.Add("attitude-indicator_indicated-roll-deg", Convert.ToDouble(values[28]));
                d.Add("attitude-indicator_internal-pitch-deg", Convert.ToDouble(values[29]));
                d.Add("attitude-indicator_internal-roll-deg", Convert.ToDouble(values[30]));
                d.Add("encoder_indicated-altitude-ft", Convert.ToDouble(values[31]));
                d.Add("encoder_pressure-alt-ft", Convert.ToDouble(values[32]));
                d.Add("gps_indicated-altitude-ft", Convert.ToDouble(values[33]));
                d.Add("gps_indicated-ground-speed-kt", Convert.ToDouble(values[34]));
                d.Add("gps_indicated-vertical-speed", Convert.ToDouble(values[35]));
                d.Add("indicated-heading-deg", Convert.ToDouble(values[36]));
                d.Add("magnetic-compass_indicated-heading-deg", Convert.ToDouble(values[37]));
                d.Add("slip-skid-ball_indicated-slip-skid", Convert.ToDouble(values[38]));
                d.Add("turn-indicator_indicated-turn-rate", Convert.ToDouble(values[39]));
                d.Add("vertical-speed-indicator_indicated-speed-fpm", Convert.ToDouble(values[40]));
                d.Add("engine_rpm", Convert.ToDouble(values[41]));

                data.Add(d);
            }
            //loop to get keys (yes, I am lazy)
            keys = new List<string>();
            foreach (KeyValuePair<string, double> p in (Dictionary<string, double>)data[0])
            {
                keys.Add(p.Key);
            }
        }
        public List<string> Properties
        {
            get
            {
                return keys;
            }
        }

        public Dictionary<string, double> getLine(int lineNumber)
        {
            if (lineNumber < data.Count)
            {
                return (Dictionary<string, double>)data[lineNumber];
            }
            return (Dictionary<string, double>)data[data.Count - 1];
        }

        public string getLineString(int lineNumber)
        {
            return (string)lines[lineNumber];
        }

        public List<double> getPropertyArray(string key)
        {
            IList values = new ArrayList();
            foreach (Dictionary<string, double> d in data)
            {
                double value = 0;
                d.TryGetValue(key, out value);
                values.Add(value);
            }
            return ConvertToListOf<double>(values);
        }


        public static List<T> ConvertToListOf<T>(IList iList)
        {
            List<T> result = new List<T>();
            foreach (T value in iList)
                result.Add(value);

            return result;
        }

        public int numOfLines()
        {
            return lines.Count;
        }
    }
}