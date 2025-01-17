﻿using System;
using System.Collections.Generic;

namespace Homework3 {
    internal class IsNumberPrimeCalculator {
        private readonly ICollection<long> _primeNumbers;
        private readonly Queue<long> _numbersToCheck;

        public IsNumberPrimeCalculator(ICollection<long> primeNumbers, Queue<long> numbersToCheck) {
            _primeNumbers = primeNumbers;
            _numbersToCheck = numbersToCheck;
        }
        private readonly object synclock = new object();
        public void CheckIfNumbersArePrime() {
            while (true) {
                {
                    var numberToCheck = _numbersToCheck.Dequeue();
                    if (IsNumberPrime(numberToCheck))
                    {
                        _primeNumbers.Add(numberToCheck);
                    }
                }
            }
        }

        private bool IsNumberPrime(long numberWeAreChecking)
        {
            lock (synclock)
            {
                const long firstNumberToCheck = 3;

                if (numberWeAreChecking % 2 == 0)
                {
                    return false;
                }
                var lastNumberToCheck = Math.Sqrt(numberWeAreChecking);
                for (var currentDivisor = firstNumberToCheck; currentDivisor < lastNumberToCheck; currentDivisor += 2)
                {
                    if (numberWeAreChecking % currentDivisor == 0)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}