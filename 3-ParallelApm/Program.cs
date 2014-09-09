using System;
using System.Diagnostics;
using System.Threading;
using _2_APM;

namespace _3_ParallelApm
{
    class Program
    {
        private static ApmPrimes[] _apmPrimes;
        private static Stopwatch _sw;

        static void Main(string[] args)
        {
            _sw = new Stopwatch();
            _sw.Start();
            const int numThreads = 10;
            _apmPrimes = new ApmPrimes[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                _apmPrimes[i] = new ApmPrimes();
                _apmPrimes[i].BeginGetPrimeNumbers(i == 0 ? 2 : i * 1000000 + 1, (i + 1) * 1000000, GetPrimesCallback, i);
            }

            Console.ReadLine();
        }

        private static int itemNo;
        private static int sumPrimes;
        private static void GetPrimesCallback(IAsyncResult ar)
        {
            Interlocked.Increment(ref itemNo);
            var threadNo = (int)ar.AsyncState;
            Interlocked.Add(ref sumPrimes, _apmPrimes[threadNo].EndGetPrimeCount(ar).Count);

            if (itemNo == 10)
                Console.WriteLine("Primes found: {0}\nTotal time: {1}", sumPrimes, _sw.ElapsedMilliseconds);
        }
    }
}
