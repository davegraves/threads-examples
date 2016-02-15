using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Tearing
{
    class Program
    {
        private static readonly Guid G1 = Guid.Empty;
        private static readonly Guid G2 = Guid.NewGuid();
        private static AtomicityExample _atomicityExample;

        private static readonly ConcurrentDictionary<Guid,int> D = new ConcurrentDictionary<Guid, int>(); 

        static void Main(string[] args)
        {
            _atomicityExample = new AtomicityExample();

            var t1 = new Thread(Writer);
            var t2 = new Thread(Reader);

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            foreach (var k in D.Keys)
            {
                Console.WriteLine(k);
            }

            Console.ReadKey();
        }

        private static void Writer()
        {
            for (int i = 0; i < 100000000; i++)
            {
                _atomicityExample.SetValue(i % 2 == 0 ? G1 : G2);
            }
        }

        private static void Reader()
        {
            for (int i = 0; i < 100000000; i++)
            {
                var g = _atomicityExample.GetValue();

                D.AddOrUpdate(g, x => 0, (x, y) => 0);
            }
        }


        class AtomicityExample
        {
            Guid _value;
            public void SetValue(Guid value) { _value = value; }
            public Guid GetValue() { return _value; }
        }
    }
}
