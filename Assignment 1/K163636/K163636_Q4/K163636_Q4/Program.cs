using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicIntArray<String> dynamicIntArray = new DynamicIntArray<String>(2);
            dynamicIntArray.AddElement("heello");
            dynamicIntArray.AddElement("bilal");
            dynamicIntArray.AddElement("google");
            dynamicIntArray.AddElement("gg");
            dynamicIntArray.DisplayAll();
            Console.ReadKey();
        }
    }
}
