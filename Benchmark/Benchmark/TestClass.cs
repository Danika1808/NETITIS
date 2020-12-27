using System;
using BenchmarkDotNet;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace Benchmark
{
    class TestClass
    {
        void SimulateWork()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
        }

        public static void PbStaticVoid()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
        }

        [Benchmark(Description = "PbVoid")]
        public void PbVoid() =>
            SimulateWork();

        [Benchmark(Description = "PbVirtualVoid")]
        public virtual void PbVirtualVoid() =>
            SimulateWork();

        public static void PbGenericStaticVoid<T>()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
        }

        public static void PbGenericStaticVoid() =>
            PbGenericStaticVoid<int>();


        [Benchmark(Description = "PbGenericVoid")]
        public void PbGenericVoid() =>
            SimulateWork();

        [Benchmark(Description = "PbDynamic")]
        public dynamic PbDynamic()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < 10000; i++)
                builder.Append(i.ToString());
            return builder;
        }
    }
}
