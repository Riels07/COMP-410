using System;
using System.Collections.Generic;
using System.IO;

namespace Homework3 {
    internal class NumberWriter : IDisposable {
        private readonly TextWriter _writer;

        public NumberWriter(FileInfo file) {
            if (File.Exists(file.FullName)) {
                File.Delete(file.FullName);
            }
            _writer = new StreamWriter(new BufferedStream(new FileStream(
                file.FullName, FileMode.Create, FileAccess.Write, FileShare.None, 8192, FileOptions.SequentialScan)));
        }
        private readonly object syncLock = new object();
        public void WriteIntegers(IEnumerable<long> values) {
            foreach (var value in values) {
                lock (syncLock)
                {
                    _writer.WriteLine(value);
                } 
            }
        }

        public void Dispose() {
            lock (syncLock)
            {
                _writer.Dispose();
            }
        }
    }
}