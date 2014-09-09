using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace _2_APM
{
    class Program
    {
        private static ApmPrimes _apmPrimes;
        private static Stopwatch _sw;

        static void Main(string[] args)
        {
            _sw = new Stopwatch();
            _sw.Start();
            _apmPrimes = new ApmPrimes();
            _apmPrimes.BeginGetPrimeNumbers(2, 10000000, GetPrimesCallback, null);
            Console.ReadLine();
        }

        private static void GetPrimesCallback(IAsyncResult ar)
        {
            Console.WriteLine("Primes found: {0}\nTotal time: {1}", _apmPrimes.EndGetPrimeCount(ar).Count, _sw.ElapsedMilliseconds); 
        }
    }
}
