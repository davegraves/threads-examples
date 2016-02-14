using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoopReadHoisting
{
    //https://msdn.microsoft.com/en-us/magazine/jj883956.aspx
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 3000; i++)
            {
                new Test(i).Run();    
            }
            
        }
    }

    class Test
    {
        private readonly int _i;
        private bool _flag = true;

        public Test(int i)
        {
            _i = i;
        }

        public void Run()
        {
            // Set _flag to false on another thread
            new Thread(() => { _flag = false; }).Start();
            // Poll the _flag field until it is set to false
            while (_flag) {
                //Console.WriteLine("Hi from {0}",_i);
            };
            // The loop might never terminate!
        }
    }
}
