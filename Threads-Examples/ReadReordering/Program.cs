using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ReadReordering
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new DataInit();
            for (int i = 0; i < 100; i++)
            {
                var t1 = new Thread(d.Init);
                var t2 = new Thread(d.Print);
                t1.Start();
                t2.Start();
                t1.Join();
                t2.Join();
            }


            Console.ReadKey();

        }
    }

    public class DataInit
    {
        public int _data = 0;
        private bool _initialized = false;
        public void Init()
        {
            _data = 42;            // Write 1
            _initialized = true;   // Write 2
        }
        public void Print()
        {  
            if (_initialized)            // Read 1
                Console.WriteLine(_data);  // Read 2
            else
                Console.WriteLine("Not initialized");
        }
    }
}
