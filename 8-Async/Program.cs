using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _8_Async
{
    class Program
    {
        static void Main(string[] args)
        {
            ProcessPrimesAsync();
            Console.ReadLine();
        }

        private static async void ProcessPrimesAsync()
        {
            var sw = new Stopwatch();
            sw.Start();
            List<int> primes = await GetPrimeNumbersAsync(2, 10000000);
            Console.WriteLine("Primes found: {0}\nTotal time: {1}", primes.Count, sw.ElapsedMilliseconds);
        }

        private static async Task<List<int>> GetPrimeNumbersAsync(int minimum, int maximum)
        {
            var count = maximum - minimum + 1;
            return await Task.Factory.StartNew(() => Enumerable.Range(minimum, count).Where(IsPrimeNumber).ToList());
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
