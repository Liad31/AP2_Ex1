using System;
using System.Collections.Generic;

namespace AP2_Ex1
{
    public interface IDatabase
    {
        Dictionary<String, double> getLine(int lineNumber);

        double [] getPropertyArray
    }
}