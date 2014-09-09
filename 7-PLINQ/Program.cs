using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _7_PLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var primes = GetPrimeNumbers(2, 10000000);
            Console.WriteLine("Primes found: {0}\nTotal time: {1}", primes.Count, sw.ElapsedMilliseconds);
        }

        private static List<int> GetPrimeNumbers(int minimum, int maximum)
        {
            var count = maximum - minimum + 1;
            return Enumerable.Range(minimum, count).AsParallel().Where(IsPrimeNumber).ToList();
        }

        static bool IsPrimeNumber(int p)
        {
            if (p % 2 == 0)
                return p == 2;
            var topLimit = (int)Math.Sqrt(p);
            for (int i = 3; i <= topLimit; i += 2)
            {
                if (p % i == 0) return false;
            }
            return true;
        }
    }
}
