using System;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var o = new Foo();
            o.A();
            o.B();

            Console.ReadKey();
        }
    }

    class Foo
    {
        private bool _done;

        public void A()
        {
            Task.Run(() => { _done = true; });
        }

        public void B()
        {
            while(true)
            {
                if (_done)
                    break;
            }
            Console.WriteLine("finished...");
        }
    }
}
