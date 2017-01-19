using System;
using System.Diagnostics;

namespace ChronoUtils
{
    public static class Chrono
    {
        public static TimeSpan MeasureTime(Action action)
        {    
            Stopwatch sw = Stopwatch.StartNew();
            action();
            sw.Stop();
            return sw.Elapsed;
        }

        public static T MeasureTime<T>(Func<T> func, out TimeSpan elapsed)
        {
            Stopwatch sw = Stopwatch.StartNew();
            var result = func();
            elapsed = sw.Elapsed;
            return result;
        }
    }
}
