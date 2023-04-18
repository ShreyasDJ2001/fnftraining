using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MultiThread
    {
        private string _data;

        public MultiThread(string data)
        {
            _data = data;
        }
        public void PerformOperation()
        {
            lock (_data)
            {
                for (int i = 0; i < _data.Length; i++)
                {
                    Console.Write(_data[i]);
                    Thread.Sleep(500);
                }

            }
            
        }
    }
    internal class multithread
    {
        static void creatMultiThread()
        {
            MultiThread instance = new MultiThread("Some content for the Demo");
            Thread th = new Thread(instance.PerformOperation);
            Thread th2 = new Thread(instance.PerformOperation);
            th.Start();
            th2.Start();
        }
        static void LargeTime()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("some operation is going on !! ");
                Thread.Sleep(1000);
                
            }

        }

        static void ThreadFunWithArg(object argForThread)
        {
            if(argForThread is Array)
            {
                var temp= (Array)argForThread;
                foreach(var item in temp)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(1000);
                }
            }
            else
            {
                throw new ArgumentException("arg should be array ");
            }

        }
        static void Main(string[] args)
        {

            //LargeTime();
            //CreatNewThread();
            //creatMultiThread();
            backGroundThread();


            Console.WriteLine("End of the Program");
            SemaphoreExample example = new SemaphoreExample(3);

            for (int i = 0; i < 10; i++)
            {
                Thread th = new Thread(example.PerformOperation);
                th.Start();
            }

            Console.ReadLine();
        }
        class SemaphoreExample
        {
            private Semaphore _semaphore;
            public SemaphoreExample(int maxThreads)
            {
                _semaphore = new Semaphore(maxThreads, maxThreads);
            }

            public void PerformOperation()
            {
                _semaphore.WaitOne();
                try
                {
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} is executing the operation");
                    Thread.Sleep(2000);
                }
                finally
                {
                    _semaphore.Release();
                    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} has released the semaphore");
                }
            }
        }



            private static void backGroundThread()
        {
            Thread th = new Thread(LargeTime);
            th.IsBackground= true;
            th.Start();
        }
        static void creatNewThreadWithArgAndExecute()
        {
            Thread tr = new Thread(ThreadFunWithArg);
            var arg = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            tr.Start(arg);
        }
        static void CreatNewThread()
        {
            Thread thread = new Thread(LargeTime);
            thread.Start();
            creatNewThreadWithArgAndExecute();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("[MAIN] function is running parally");
                Thread.Sleep(1000);
            }
        }
    }
}


/// assignment Try out an example on semaphore where u can allow
/// In the above code, i have created a semaphoreExample class that takes in the maximum number of threads that can execute concurrently as a parameter
/// and create a semaphore object with this maximum count and use it to control access to the shared resource