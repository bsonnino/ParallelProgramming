using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Task
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            const int numThreads = 10;
            var primes = new Task<List<int>>[numThreads];
            for (int i = 0; i < numThreads; i++)
            {
                int index = i;
                primes[i] = Task.Factory.StartNew(() => GetPrimeNumbers(index == 0 ? 2 : index * 1000000 + 1, (index + 1) * 1000000));
            }
            Task.WaitAll(primes); 
            Console.WriteLine("Primes found: {0}\nTotal time: {1}", primes.Sum(p => p.Result.Count), sw.ElapsedMilliseconds);
        }

        private static List<int> GetPrimeNumbers(int minimum, int maximum)
        {
            var count = maximum - minimum + 1;
            return Enumerable.Range(minimum, count).Where(IsPrimeNumber).ToList();
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
