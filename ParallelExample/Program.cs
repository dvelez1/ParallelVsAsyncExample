using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelExample
{
    class Program
    {
        static void Main(string[] args)
        {
           
               //***********************
            var watch = System.Diagnostics.Stopwatch.StartNew();
            CallModularExample();
            watch.Stop();
            Console.WriteLine($"Execution Time Modular Example: {watch.ElapsedMilliseconds} ms");
            //***********************
            Console.WriteLine("");
            Console.WriteLine("******************");
            Console.WriteLine("");
            //***********************
            watch = System.Diagnostics.Stopwatch.StartNew();
            CallParallelExample();
            watch.Stop();
            Console.WriteLine($"Execution Time Parallel Example 1: {watch.ElapsedMilliseconds} ms");
            //***********************
            Console.WriteLine("");
            Console.WriteLine("******************");
            Console.WriteLine("");

            //***********************
            watch = System.Diagnostics.Stopwatch.StartNew();
            CallParallelExample2();
            watch.Stop();
            Console.WriteLine($"Execution Time Parallel Example 2 (Parallel.For) : {watch.ElapsedMilliseconds} ms");
            //***********************
            Console.WriteLine("");
            Console.WriteLine("******************");
            Console.WriteLine("");

            //***********************
            //Note: // This method runs asynchronously.
            Console.WriteLine("Next Method runs asynchronously.");
            watch = System.Diagnostics.Stopwatch.StartNew();
            AwaitExample();
            watch.Stop();
            Console.WriteLine($"Execution Time AsyncAwait Example 2: {watch.ElapsedMilliseconds} ms");
            //***********************

            Console.ReadKey();
        }



       #region MethodsForParallelAsyncExample


        static void CallModularExample()
        {
            for (int i = 0; i < 3; i++)
            {
                JobExample();
            }

        }
        
        static void CallParallelExample()
        {

            Parallel.Invoke(JobExample, JobExample, JobExample);

        }
        

        static void CallParallelExample2()
        {
            Parallel.For(0, 3,
              index => {
                  JobExample();
              });
        }

        static async void AwaitExample()
        {
            for (int i = 0; i < 3; i++)
            {
                await Task.Run(() => JobExample());
            }

        }
                

        static void JobExample()
        {
            Thread.Sleep(1000);
            Console.WriteLine("JobExample");
        
        }

        #endregion




    }
}
