using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3 {
    class NumberReader : IDisposable {
        private readonly TextReader _reader;
        private readonly object synclock = new object();

        public NumberReader(FileInfo file) {
            _reader = new StreamReader(new BufferedStream(new FileStream(
                file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read, 4096, FileOptions.SequentialScan), 65536));
        }

        public IEnumerable<long> ReadIntegers() {
            string line;
            lock (synclock)
            {
                while ((line = _reader.ReadLine()) != null)
                {
                    var value = long.Parse(line);
                    yield return value;
                }
            }
        }

        public void Dispose() {
            {
                _reader.Dispose();
            }
        }
    }
}