using System.Collections.Generic;
using System.Linq;

namespace Benchmark
{
    public class Result
    {
        public bool IsValid => Errors.Count == 0;
        public string Value { get; set; }
        public List<string> Errors { get; set; }

        public static Result Success(string value)
        {
            return new Result {Value = value};
        }

        public static Result Fail(params string[] errors)
        {
            return new Result {Errors = errors.ToList()};
        }
    }

    public class ResultBenchmarkController
    {
        private readonly ResultBenchmarkManager _manager;

        public ResultBenchmarkController(ResultBenchmarkManager manager)
        {
            _manager = manager;
        }

        public string GetSomething()
        {
            var result = _manager.GetSomething();

            return result.IsValid ? result.Value : string.Join(", ", result.Value);
        }
    }

    public class ResultBenchmarkManager
    {
        private readonly ResultBenchmarkRepository _repository;

        public ResultBenchmarkManager(ResultBenchmarkRepository repository)
        {
            _repository = repository;
        }

        public Result GetSomething()
        {
            var result = _repository.GetSomething();
            if (!result.IsValid) return result;

            return Result.Success(result.Value + " foo");
        }
    }

    public class ResultBenchmarkRepository
    {
        public Result GetSomething()
        {
            return Result.Fail("Obligame perro!");
        }
    }
}
