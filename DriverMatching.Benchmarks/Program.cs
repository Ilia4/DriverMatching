using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DriverMatching.Benchmarks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<DriverBenchmarks>();
        }
    }

    [MemoryDiagnoser]
    public class DriverBenchmarks
    {
        private DriverMap map = new DriverMap(100, 100);

        [Params(100, 500)]
        public int DriverCount { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            map = new DriverMap(100, 100);

            for (int i = 0; i < DriverCount; i++)
            {
                int x = i % 100;
                int y = i / 100;

                map.AddOrUpdateDriver(i + 1, x, y);
            }
        }

        [Benchmark]
        public List<Driver> Sorting()
        {
            return DriverSearch.FindNearestBySorting(map, 50, 50);
        }

        [Benchmark]
        public List<Driver> Search()
        {
            return DriverSearch.FindNearestBySearch(map, 50, 50);
        }

        [Benchmark]
        public List<Driver> Queue()
        {
            return DriverSearch.FindNearestByQueue(map, 50, 50);
        }
    }
}
