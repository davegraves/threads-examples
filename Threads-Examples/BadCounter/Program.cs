using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        private static long _counter;
        private static object o = new object();

        static void Main(string[] args)
        {
            var ct1 = new Thread(Increment);
            var ct2 = new Thread(Increment);

            ct1.Start();
            ct2.Start();

            ct1.Join();
            ct2.Join();

            Console.WriteLine(_counter);
            Console.ReadKey();
        }

        static void Increment()
        {
            for (int i = 0; i < 100000000; i++)
            {
                _counter++;
            }
        }
    }
}
