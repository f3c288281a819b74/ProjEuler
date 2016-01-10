﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjEuler
{
    public class ProjEuler
    {
        public static int Problem001(int limit)
        {
            int sum = 0;
            for (int i = 1; i < limit; ++i)
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            return sum;
        }

        public static int Problem002(int limit)
        {
            // prepare fibonacci sequence
            const int estimatedSize = 40;
            var fibonacci = new int[estimatedSize];
            int i, j;
            fibonacci[0] = 1;
            fibonacci[1] = 2;
            for (i = 0, j = 2; j < estimatedSize; ++i, ++j)
            {
                fibonacci[j] = fibonacci[i] + fibonacci[i+1];
                if (fibonacci[j] > limit)
                    break;
            }
            if (j >= estimatedSize && fibonacci[estimatedSize - 1] < limit)
                throw new Exception("Wrong buffer estimate. Buffer to small.");
            // find sum of even elements
            int sum = 0;
            for (i = j - 1; i > 0; --i)
            {
                if (!((fibonacci[i] & 1) == 1))
                    sum += fibonacci[i];
            }
            return sum;
        }

        public static long Problem003(long number)
        {
            const int estimatedSize = 7000;
            var primes = Util.Eratosthenes(estimatedSize);
            var factors = new List<int>();
            foreach (var prime in primes)
            {
                while (number % prime == 0)
                {
                    number /= prime;
                    factors.Add(prime);
                }
            }
            if (number != 1)
                throw new Exception("Wrong buffer estimate. Buffer to small.");
            return factors[factors.Count - 1];
        }

        public static int Problem004(int digits)
        {
            // TODO: optimize this brute force approach
            int tmp;
            int largest = 0;
            int upperLimit = (int)Math.Pow(10, digits) - 1;
            int lowerLimit = (int)Math.Pow(10, digits - 1) - 1;
            for (int i = upperLimit; i > lowerLimit; --i)
            {
                for (int j = upperLimit; j > lowerLimit; --j)
                {
                    tmp = i * j;
                    if (Util.Reverse(tmp.ToString()) == tmp.ToString())
                    {
                        if (tmp > largest)
                            largest = tmp;
                    }
                }
            }
            return largest;
        }

        public static int Problem005(int from, int to)
        {
            // TODO: optimize this brute force approach
            if (from == 1)
                from = 2;
            Func<int, bool> condition = (number) =>
            {
                for (int i = from; i <= to; ++i)
                {
                    if (number % i != 0)
                        return false;
                }
                return true;
            };
            int result = 0;
            for (int i = to; ; ++i)
            {
                if (condition(i))
                {
                    result = i;
                    break;
                }
            }
            return result;
        }

        public static int Problem006(int limit)
        {
            int sumSqr = 0;
            int sqrSum = 0;
            for (int i = 1; i <= limit; ++i)
            {
                sumSqr += i * i;
                sqrSum += i;
            }
            return (sqrSum * sqrSum) - sumSqr;
        }

        public static int Problem007(int primeIndex)
        {
            var primes = new List<int>();
            for (int estimate = primeIndex * 11; primes.Count < primeIndex; estimate *= 11)
            {
                primes = Util.Eratosthenes(estimate);
            }
            return primes[primeIndex - 1];
        }
    }
}
