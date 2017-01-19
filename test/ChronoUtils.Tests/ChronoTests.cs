using ChronoUtils;
using System;
using Xunit;

namespace Tests
{
    public class Tests
    {
        public void SleepFor(TimeSpan timeSpan)
        {
            System.Threading.Thread.Sleep((int)timeSpan.TotalMilliseconds);
        }

        public int SleepForAndReturnInt(TimeSpan timeSpan)
        {
            SleepFor(timeSpan);
            return 5;
        }

        [Fact]
        public void CorrectMeasureAction() 
        {
            TimeSpan timePassed = Chrono.Measure(() => SleepFor(TimeSpan.FromMilliseconds(5000)));
            Assert.True(timePassed.TotalMilliseconds >= 5000);
        }

        [Fact]
        public void CorrectMeasureFunc() 
        {
            TimeSpan timePassed;
            int result = Chrono.Measure(() => SleepForAndReturnInt(TimeSpan.FromMilliseconds(5000)), out timePassed);
            Assert.True(timePassed.TotalMilliseconds >= 5000);
            Assert.Equal(5, result);
        }
    }
}
