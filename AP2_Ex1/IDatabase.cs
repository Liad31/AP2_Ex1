using System;
using System.Collections.Generic;
using System.Collections;

namespace AP2_Ex1
{
    public interface IDatabase
    {
        /// <summary>
        /// Returns a dictionary with contained info of given line
        /// </summary>
        /// <param name="lineNumber">Line number we want to get</param>
        /// <returns>info</returns>
        Dictionary<String, double> getLine(int lineNumber);

        /// <summary>
        /// Get the line as a string, as it was in the CSV file.
        /// </summary>
        /// <param name="lineNumber">Line number we want to get</param>
        /// <returns>The string</returns>
        string getLineString(int lineNumber);

        IList Properties { get; }
        IList getPropertyArray(string name);
    }
}