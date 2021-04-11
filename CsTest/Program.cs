using System;
using System.Runtime.InteropServices;
using System.Reflection;

namespace Sandbox
{
    class Program
    {
        //Entity(String^ name, float xPos, float yPos);

        static void Main(string[] args)
        {
            var dll = Assembly.LoadFile(@"C:\Users\liad3\source\repos\DLLmaybe\Debug\Wrapper.dll");
            object[] argsEntity = { @"E:\Users\Liad\Downloads\reg_flight.csv" };
            dynamic ts = Activator.CreateInstance(dll.GetType("Wrapper.TimeSeries"), argsEntity);
            dynamic SimpleAd = Activator.CreateInstance(dll.GetType("Wrapper.SimpleAnomalyDetector"));
            SimpleAd.learnNormal(ts);
            var arr = SimpleAd.detect(@"E:\Users\Liad\Downloads\anomaly_flight.csv");
            Console.ReadKey();
        }
    }
}