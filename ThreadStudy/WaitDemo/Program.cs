using System;
using System.Collections.Generic;
using System.Threading;

namespace WaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main thread started.");

            Thread t1 = new Thread(new ThreadStart(ThreadPrint));
            Console.WriteLine("Start thread t1");
            t1.Start();
            Console.WriteLine("T1 will join 3 seconds.");
            //若想使用t1阻止调用线程，则需要在调用线程里调用t1.join，若在t1的方法里调用，则阻止的是ThreadPrint方法的执行
            t1.Join(3000);
            Console.WriteLine("Main thread resume");
            Console.WriteLine("Main thread print:this is main thread.");
            Console.WriteLine("Main thread end");

            Console.ReadLine();
        }

        private static void ThreadPrint()
        {
            Console.WriteLine("T1 started.");

            Console.WriteLine("T1 will sleep 5 seconds.");

            Thread.Sleep(5000);
            Console.WriteLine("Print:hello world!");

            Console.WriteLine("T1 end.");
        }
    }
}
