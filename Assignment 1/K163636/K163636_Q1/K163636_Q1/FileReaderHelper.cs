using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K163636_Q1
{
    class FileReaderHelper
    {
        public String path = "c:\\users\\home\\documents\\visual studio 2017\\Projects\\K163636_Q1\\K163636_Q1\\FileToRead.txt";
        public Zone[] ReadData()
        {
            List<Zone> zoneCollection = new List<Zone>(); ;
            try
            {
                using (var f = new StreamReader(path))
                {
                    string line = string.Empty;
                    while ((line = f.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        zoneCollection.Add(new Zone(Convert.ToString(parts[0]), Convert.ToString(parts[1])));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }
            Zone[] zone = zoneCollection.ToArray();
            return zone;
        }
    }
}
