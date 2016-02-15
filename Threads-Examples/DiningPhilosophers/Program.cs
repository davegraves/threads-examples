using System;
using System.Threading;

namespace DiningPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            var sticks = new Chopstick[5];
            for (int i = 0; i < 5; i++)
            {
                sticks[i] = new Chopstick();
            }

            var philosophers = new Philosopher[5];
            for (int i = 0; i < 5; i++)
            {
                philosophers[i] = new Philosopher(sticks[i],sticks[(i + 1) % 5],(i + 1).ToString());
            }

            var threads = new Thread[5];
            for (int i = 0; i < 5; i++)
            {
                threads[i] = new Thread(philosophers[i].Run);
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }
            
            threads[0].Join();
        }
    }


    class Philosopher
    {
        private readonly Chopstick _left;
        private readonly Chopstick _right;
        private readonly string _name;
        private Random _random;

        public Philosopher(Chopstick left, Chopstick right,string name)
        {
            _left = left;
            _right = right;
            _name = name;
            _random = new Random();
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(_random.Next(10,500));
                lock (_left)
                {
                    lock (_right)
                    {
                        _random = new Random();
                        Thread.Sleep(_random.Next(10,500));
                        Console.WriteLine("{0} is eating",_name);
                    }
                }
            }
        }
    }

    internal class Chopstick
    {
        
    }
}
