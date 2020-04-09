using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicIntArray dynamicIntArray = new DynamicIntArray(2);
            dynamicIntArray.AddInt(1);
            dynamicIntArray.AddInt(2);
            dynamicIntArray.AddInt(3);
            dynamicIntArray.AddInt(4);
            dynamicIntArray.DisplayAll();
            Console.WriteLine("Sun is " + dynamicIntArray.getSum());
            Console.ReadKey();
        }
    }
}
