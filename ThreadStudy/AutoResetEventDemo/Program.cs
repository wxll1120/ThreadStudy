using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AutoResetEventDemo
{
    class Program
    {
        static AutoResetEvent autoReset;

        static void Main(string[] args)
        {
            Console.WriteLine("{0}:Main thread start.", DateTime.Now.ToString());
            autoReset = new AutoResetEvent(false);

            Thread printThread = new Thread(new ParameterizedThreadStart(PrintThread));

            printThread.Start("1");
            Console.WriteLine("{0}:Main thread waitone.", DateTime.Now.ToString());
            autoReset.WaitOne();

            Console.WriteLine("{0}:Main thread this is a message from main thread.", DateTime.Now.ToString());

            Console.WriteLine("{0}:Main thread start second print thread.", DateTime.Now.ToString());

            Thread secondThread = new Thread(new ParameterizedThreadStart(PrintThread));
            secondThread.Start("2");
            
            Console.WriteLine("{0}:Main thread waitone.", DateTime.Now.ToString());

            autoReset.WaitOne();

            Console.WriteLine("{0}:Main thread end.", DateTime.Now.ToString());
            Console.ReadLine();
        }

        static void PrintThread(object threadName)
        {
            Console.WriteLine("{0}:Print thread {1} will sleep 5 seconds.", DateTime.Now.ToString(), threadName);

            Thread.Sleep(5000);

            Console.WriteLine("{0}:Print thread {1} this is a message from print thread.", DateTime.Now.ToString(), threadName);
            Console.WriteLine("{0}:Print thread {1} end.", DateTime.Now.ToString(), threadName);
            Console.WriteLine("{0}:Print thread {1} AutoResetEvent set.", DateTime.Now.ToString(), threadName);
            autoReset.Set();
        }
    }
}
