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

        /// <summary>
        /// The keys we have, list of strings.
        /// </summary>
        List<string> Properties { get; }

       /// <summary>
       /// Get a list of all the data under the given property, sorted as it was in  the CSV file.
       /// </summary>
       /// <param name="key">key we want to get</param>
       /// <returns>List of doubles od the data</returns>
        List<double> getPropertyArray(string key);

        /// <summary>
        /// returns number of lines of info
        /// </summary>
        /// <returns>num of lines</returns>
        int numOfLine();
    }
}