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
        static void Main(string[] args)
        {

            var counter = new counter();
            var ct1 = new CountingThread(counter);
            var ct2 = new CountingThread(counter);

            ct1.Run();
            ct2.Run();

            ct1.Join();
            ct2.Join();

            Console.WriteLine(counter.Count);
            Console.ReadKey();
            

        }


    }

    class CountingThread 
    {
        private readonly counter _c;
        private Thread _thread;

        public CountingThread(counter c)
        {
            _c = c;
        }

        public void Run()
        {
            _thread = new Thread(DoSomeCounting);
            _thread.Start();
        }
        public void Join()
        {
            _thread.Join();
        }

        private void DoSomeCounting()
        {
            for (int i = 0; i < 100000; i++)
            {
                _c.increment();
            }
        }
        
    }

    class counter
    {
        private int count;
        public void increment()
        {
            ++count;
        }

        public int Count { get { return count; } }
    }
}
