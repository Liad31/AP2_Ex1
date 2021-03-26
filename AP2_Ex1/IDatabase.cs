using System;
using System.Collections.Generic;
using System.Collections;

namespace AP2_Ex1
{
    public interface IDatabase
    {
        Dictionary<String, double> getLine(int lineNumber);
        string getLineString(int lineNumber);

        List<string> Properties { get; }
        List<double> getPropertyArray(string name);
    }
}