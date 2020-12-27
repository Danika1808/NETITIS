using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace Benchmark
{
    class EasiestTest
    {
        public static void OnTestsStart() =>
            BenchmarkRunner.Run<TestClass>();
    }
}
