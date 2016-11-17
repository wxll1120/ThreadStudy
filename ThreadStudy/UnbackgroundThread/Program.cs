using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UnbackgroundThread
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0}:Main thread start", DateTime.Now.ToString());

            Thread printThread = new Thread(new ThreadStart(PrintThread));
            Console.WriteLine("{0}:Print thread start.", DateTime.Now.ToString());
            printThread.Start();

            Console.WriteLine("{0}:Main thread this is a message from main thread.", DateTime.Now.ToString());
            Console.WriteLine("{0}:Main thread end.", DateTime.Now.ToString());
        }

        static void PrintThread()
        {
            Console.WriteLine("{0}:Print thread will sleep 5 seconds.", DateTime.Now.ToString());

            Thread.Sleep(5000);

            Console.WriteLine("{0}:Print thread this is a message from print thread.", DateTime.Now.ToString());
            Console.WriteLine("{0}:Print thread end.", DateTime.Now.ToString());

            Console.ReadLine();
        }
    }
}
