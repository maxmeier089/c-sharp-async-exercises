using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSVReader
{
    class Program
    {
        static async Task Main(string[] args)
        {
            CSVReader reader = new CSVReader();

            List<CSVEntry> entries = await reader.ReadFile("Fruits.CSV");

            entries.ForEach(entry => Console.WriteLine(entry.ToString()));
            
        }
    }
}
