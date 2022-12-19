using System.Diagnostics;
using BenchmarkDotNet.Attributes;

namespace EffectiveStopWatch
{
    [MemoryDiagnoser()]
    public class ValueStopwatch
    {
        [Benchmark]
        public TimeSpan OldLoop()
        {
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < 500; i++)
            {
                DoSomething();
            }

            return sw.Elapsed;
        }

        [Benchmark]
        public TimeSpan NewLoop()
        {
            var ts = Stopwatch.GetTimestamp();
            for (var i = 0; i < 500; i++)
            {
                DoSomething();
            }

            return Stopwatch.GetElapsedTime(ts);
        }

        private void DoSomething()
        {
        }
    }
}