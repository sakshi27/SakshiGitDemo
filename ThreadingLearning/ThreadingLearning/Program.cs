using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingLearning
{

    public class Alpha
    {
        public bool Running { get; set; }

        public Alpha()
        {
            Running = true;
        }

        public void printSample()
        {
            Console.WriteLine("Running the applicaiton on thread :: {0}", Thread.CurrentThread.Name);
            while (Running)
            {
                Thread.Sleep(500);
                var thread = new Thread(new ThreadStart(this.printSample));
                thread.Name = "" + Guid.NewGuid().ToString();
                thread.Start();
            }
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var alpha = new Alpha();
            alpha.printSample();
            var timeout = new TimeSpan(0, 2, 0);
            Thread.Sleep(timeout);
            alpha.Running = false;
        }
    }
}
