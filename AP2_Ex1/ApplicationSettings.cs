using System;

namespace AP2_Ex1
{
    public class ApplicationSettings
    {
        public string FlightGearPath { get; set; }
        public string FlightCsvPath { get; set; }
        public string TrainingCsvPath { get; set; }
        public ApplicationSettings(){}
        public ApplicationSettings(string flightGearPath = null, string flightCsvPath = null, string trainingCsvPath = null)
        {
            this.FlightGearPath = flightGearPath;
            this.FlightCsvPath = flightCsvPath;
            this.TrainingCsvPath = trainingCsvPath;
        }
    }
}