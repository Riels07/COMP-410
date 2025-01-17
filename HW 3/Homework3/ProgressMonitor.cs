﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework3 {
    internal class ProgressMonitor {
        private readonly List<long> _results;
        public long TotalCount = 0;

        public ProgressMonitor(List<long> results) {
            _results = results;
        }
        private readonly object synclock = new object();
        public void Run() {
            lock (synclock)
            {
                while (true)
                {
                    Thread.Sleep(100); // wait for 1/10th of a second

                    var currentcount = _results.Count;
                    TotalCount += currentcount;

                    _results.Clear(); // clear out the current primes to save some memory

                    if (currentcount > 0)
                    {
                        Console.WriteLine("{0} primes found so far", TotalCount);
                    }
                }
            }
        }
    }
}