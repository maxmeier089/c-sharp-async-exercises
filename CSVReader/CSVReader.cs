using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSVReader
{
    public class CSVReader
    {

        public async Task<List<CSVEntry>> ReadFile(string fileName)
        {
            return await Task.Run(() =>
            {
                List<CSVEntry> entries = new List<CSVEntry>();

                File.ReadLines(fileName).ToList().ForEach(line =>
                {
                    string[] lineSplit = line.Split(';');

                    entries.Add(new CSVEntry() { Entry = lineSplit });
                });

                return entries;
            });
        }

    }
}
