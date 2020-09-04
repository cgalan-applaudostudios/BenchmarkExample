using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Benchmark
{
    public class ExceptionVsResult
    {
        private readonly ExceptionBenchmarkController _ebc;
        private readonly ResultBenchmarkController _rbc;

        public ExceptionVsResult()
        {
            var ebr = new ExceptionBenchmarkRepository();
            var ebm = new ExceptionBenchmarkManager(ebr);
            _ebc = new ExceptionBenchmarkController(ebm);

            var rbr = new ResultBenchmarkRepository();
            var rbm = new ResultBenchmarkManager(rbr);
            _rbc = new ResultBenchmarkController(rbm);
        }

        [Benchmark]
        public string Exception()
        {
            return _ebc.GetSomething();
        }

        [Benchmark]
        public string Result()
        {
            return _rbc.GetSomething();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ExceptionVsResult>();
        }
    }
}
