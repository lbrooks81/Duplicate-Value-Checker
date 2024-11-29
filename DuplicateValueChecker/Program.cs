using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Diagnostics.Tracing.Parsers.MicrosoftWindowsTCPIP;

namespace DuplicateValueChecker
{
    public class Program
    {
        public static void Main()
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }

    [MemoryDiagnoser]
    [MaxIterationCount(24)]
    public class Benchmark
    {
        [Params(100, 1000, 10000)] // N can be 100, 1000, or 10000
        public int N { get; set; }

        private int[] array;

        [GlobalSetup] // Runs before running any benchmarks
        public void GlobalSetup()
        {
            int duplicatePlacement = N - 1;
            array = Enumerable.Range(0, N).ToArray();
            array[duplicatePlacement] = N / 2;
        }

        [Benchmark]
        public bool HasDuplicateValue1()
        {
            for(int i = 0; i < array.Length; i++) 
            {
                for(int j = 0; j < array.Length; j++)
                {
                    if (i != j && array[i] == array[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        
        
        [Benchmark]
        public bool HasDuplicateValue2()
        {
            // HashSet is like a list but it can only contain unique values
            HashSet<int> existingNumbers = [];

            foreach(int num in array)
            {
                if(existingNumbers.Add(num) == false)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
