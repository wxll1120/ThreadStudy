using System;
using System.Collections.Generic;
using System.Threading;

namespace WaitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0}:Main thread started.", DateTime.Now.ToString());

            Thread t1 = new Thread(new ThreadStart(ThreadPrint));
            Console.WriteLine("{0}:Main thread Start thread t1", DateTime.Now.ToString());
            t1.Start();
            Console.WriteLine("{0}:Main thread T1 will join 3 seconds.", DateTime.Now.ToString());
            //若想使用t1阻止调用线程，则需要在调用线程里调用t1.join，若在t1的方法里调用，则阻止的是ThreadPrint方法的执行
            t1.Join(3000);
            Console.WriteLine("{0}:Main thread resume", DateTime.Now.ToString());
            Console.WriteLine("{0}:Main thread print:this is main thread.", DateTime.Now.ToString());
            Console.WriteLine("{0}:Main thread end", DateTime.Now.ToString());

            Console.ReadLine();
        }

        private static void ThreadPrint()
        {
            Console.WriteLine("{0}:T1 started.", DateTime.Now.ToString());

            Console.WriteLine("{0}:T1 will sleep 5 seconds.", DateTime.Now.ToString());

            Thread.Sleep(5000);
            Console.WriteLine("{0}:T1 Print:hello world!", DateTime.Now.ToString());

            Console.WriteLine("{0}:T1 end.", DateTime.Now.ToString());
        }
    }
}
