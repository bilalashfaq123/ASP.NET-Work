using K163636_Q1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace k163636_Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            FileReaderHelper fileReaderHelper = new FileReaderHelper();
            Zone[] zoneArray = fileReaderHelper.ReadData();
            for (int i = 0; i < zoneArray.Length; i++)
            {
                Console.WriteLine("Zone Name " + zoneArray[i].ZoneName + "  Zone Status  " + zoneArray[i].Status);
            }
            Console.ReadKey();
        }
    }
}
