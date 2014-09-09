using System;
using System.Collections.Generic;
using System.Linq;

namespace _2_APM
{
    public class ApmPrimes
    {
        private List<int> GetPrimeNumbers(int minimum, int maximum)
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

        private delegate List<int> GetPrimesDelegate(int min, int count);
        private GetPrimesDelegate _getPrimesDelegate;

        public IAsyncResult BeginGetPrimeNumbers(int minimum, int maximum, AsyncCallback callback, object userState)
        {
            _getPrimesDelegate = GetPrimeNumbers;
            return _getPrimesDelegate.BeginInvoke(minimum, maximum, callback, userState);
        }
        public List<int> EndGetPrimeCount(IAsyncResult result)
        {
            return _getPrimesDelegate.EndInvoke(result);
        }

    }
}
