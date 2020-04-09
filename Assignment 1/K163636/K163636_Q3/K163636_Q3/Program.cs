using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicIntArray dynamicArrayInt = new DynamicIntArray(1000000);
            ArrayList arrayList = new ArrayList();
            List<int> list = new List<int>();
            int[] array = new int[1000000];

            Random random = new Random();
            Stopwatch stopwatch = new Stopwatch();
            Console.WriteLine("DynamicIntArray");
            Console.WriteLine();
            #region [DynamicIntArray]
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                dynamicArrayInt.AddInt(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan DynamicArrayTimespanforInsertion = stopwatch.Elapsed;
            Console.WriteLine("Generate Num \t{0:D2}:{1:D2}:{2:D2}", DynamicArrayTimespanforInsertion.Minutes, DynamicArrayTimespanforInsertion.Seconds, DynamicArrayTimespanforInsertion.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            dynamicArrayInt.getSum();
            stopwatch.Stop();
            TimeSpan DynamicArrayTimespanforSum = stopwatch.Elapsed;
            Console.WriteLine("Sum \t\t{0:D2}:{1:D2}:{2:D2}", DynamicArrayTimespanforSum.Minutes, DynamicArrayTimespanforSum.Seconds, DynamicArrayTimespanforSum.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 5; i++)
            {
                dynamicArrayInt.indexOf(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan DynamicArrayTimespanforFindings = stopwatch.Elapsed;
            Console.WriteLine("Find Num \t{0:D2}:{1:D2}:{2:D2}", DynamicArrayTimespanforFindings.Minutes, DynamicArrayTimespanforFindings.Seconds, DynamicArrayTimespanforFindings.Milliseconds);
            #endregion


            #region [ArrayList]
            Console.WriteLine();
            Console.WriteLine("ArrayList");
            Console.WriteLine();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                arrayList.Add(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan ArrayListTimespanforInsertion = stopwatch.Elapsed;
            Console.WriteLine("Generate Num \t{0:D2}:{1:D2}:{2:D2}", ArrayListTimespanforInsertion.Minutes, ArrayListTimespanforInsertion.Seconds, ArrayListTimespanforInsertion.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            long sum = 0;
            foreach (int item in arrayList)
            {
                sum += item;
            }
            stopwatch.Stop();
            TimeSpan ArrayListTimespanforSum = stopwatch.Elapsed;
            Console.WriteLine("Sum \t\t{0:D2}:{1:D2}:{2:D2}", ArrayListTimespanforSum.Minutes, ArrayListTimespanforSum.Seconds, ArrayListTimespanforSum.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 5; i++)
            {
                arrayList.IndexOf(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan ArrayListTimespanforFindings = stopwatch.Elapsed;
            Console.WriteLine("Find Num \t{0:D2}:{1:D2}:{2:D2}", ArrayListTimespanforFindings.Minutes, ArrayListTimespanforFindings.Seconds, ArrayListTimespanforFindings.Milliseconds);
            #endregion


            #region [List]
            Console.WriteLine();
            Console.WriteLine("List");
            Console.WriteLine();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                list.Add(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan ListTimespanforInsertion = stopwatch.Elapsed;
            Console.WriteLine("Generate Num \t{0:D2}:{1:D2}:{2:D2}", ListTimespanforInsertion.Minutes, ListTimespanforInsertion.Seconds, ListTimespanforInsertion.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            //sum 
            list.Sum();
            stopwatch.Stop();
            TimeSpan ListTimespanforSum = stopwatch.Elapsed;
            Console.WriteLine("Sum \t\t{0:D2}:{1:D2}:{2:D2}", ListTimespanforSum.Minutes, ListTimespanforSum.Seconds, ListTimespanforSum.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 5; i++)
            {
                list.IndexOf(random.Next(100));
            }
            stopwatch.Stop();
            TimeSpan ListTimespanforFindings = stopwatch.Elapsed;
            Console.WriteLine("Find Num \t{0:D2}:{1:D2}:{2:D2}", ListTimespanforFindings.Minutes, ListTimespanforFindings.Seconds, ListTimespanforFindings.Milliseconds);
            #endregion


            #region [Array]
            Console.WriteLine();
            Console.WriteLine("Array");
            Console.WriteLine();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
            {
                array[i] = random.Next(100);
            }
            stopwatch.Stop();
            TimeSpan ArrayTimespanforInsertion = stopwatch.Elapsed;
            Console.WriteLine("Generate Num \t{0:D2}:{1:D2}:{2:D2}", ArrayTimespanforInsertion.Minutes, ArrayTimespanforInsertion.Seconds, ArrayTimespanforInsertion.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            //sum 
            long sumArray = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sumArray += array[i];
            }
            stopwatch.Stop();
            TimeSpan ArrayTimespanforSum = stopwatch.Elapsed;
            Console.WriteLine("Sum \t\t{0:D2}:{1:D2}:{2:D2}", ArrayTimespanforSum.Minutes, ArrayTimespanforSum.Seconds, ArrayTimespanforSum.Milliseconds);
            stopwatch.Reset();
            stopwatch.Start();
            for (int i = 0; i < 5; i++)
            {
                int randomNumber = random.Next(100);
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[i] == randomNumber)
                    {
                        break;
                    }
                }
            }
            stopwatch.Stop();
            TimeSpan ArrayTimespanforFindings = stopwatch.Elapsed;
            Console.WriteLine("Find Num \t{0:D2}:{1:D2}:{2:D2}", ArrayTimespanforFindings.Minutes, ArrayTimespanforFindings.Seconds, ArrayTimespanforFindings.Milliseconds);
            #endregion


            Console.ReadKey();

        }
    }
}
