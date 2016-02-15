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
    //http://stackoverflow.com/questions/23110762/can-this-c-sharp-code-fail-because-of-a-value-in-a-register-or-cache-never-getti
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
