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

            Console.WriteLine("******************");

            //***********************
            watch = System.Diagnostics.Stopwatch.StartNew();
            CallParallelExample();
            watch.Stop();
            Console.WriteLine($"Execution Time Parallel Example: {watch.ElapsedMilliseconds} ms");
            //***********************

            Console.WriteLine("******************");

            //***********************
            //Note: // This method runs asynchronously.
            Console.WriteLine("Next Method runs asynchronously.");
            watch = System.Diagnostics.Stopwatch.StartNew();
            AwaitExample();
            watch.Stop();
            Console.WriteLine($"Execution Time AsyncAwait Example: {watch.ElapsedMilliseconds} ms");
            //***********************


            Console.WriteLine("******************");

            Console.ReadKey();
        }



        static void CallModularExample()
        {
            for (int i = 0; i < 3; i++)
            {
                NoCottoNo();
            }

        }


        static void CallParallelExample()
        {
          
              Parallel.Invoke( NoCottoNo, NoCottoNo, NoCottoNo);
           
        }



        static async void AwaitExample()
        {
            for (int i = 0; i < 3; i++)
            {
                await Task.Run(() => NoCottoNo());
            }
            
        }




        static void NoCottoNo()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Cotto  --> NoNoNo");
        }




    }
}
