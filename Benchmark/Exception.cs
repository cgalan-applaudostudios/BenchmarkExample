using System;

namespace Benchmark
{
    public class ExceptionBenchmarkController
    {
        private readonly ExceptionBenchmarkManager _manager;

        public ExceptionBenchmarkController(ExceptionBenchmarkManager manager)
        {
            _manager = manager;
        }

        public string GetSomething()
        {
            try
            {
                return _manager.GetSomething();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }

    public class ExceptionBenchmarkManager
    {
        private readonly ExceptionBenchmarkRepository _repository;

        public ExceptionBenchmarkManager(ExceptionBenchmarkRepository repository)
        {
            _repository = repository;
        }

        public string GetSomething()
        {
            var something = _repository.GetSomething();
            return something + " foo";
        }
    }

    public class ExceptionBenchmarkRepository
    {
        public string GetSomething()
        {
            throw new NotImplementedException("Obligame perro");
        }
    }
}
