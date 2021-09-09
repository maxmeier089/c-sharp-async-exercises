using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSVReader;

namespace FruitStand
{
    public class Search
    {

        public async Task<List<FruitSearchResult>> SearchFruits(string name)
        {
            return await Task.Run(async () =>
            {
                // create result list
                List<FruitSearchResult> result = new List<FruitSearchResult>();

                // convert name to lowercase
                string nameLower = name.ToLower();

                try
                {
                    // read CSV entries
                    CSVReader.CSVReader reader = new CSVReader.CSVReader();

                    List<CSVEntry> csvEntries = await reader.ReadFile("Fruits.CSV");

                    foreach (CSVEntry csvEntry in csvEntries)
                    {
                        // get name
                        string entryName = csvEntry.Entry[1];

                        // check if name matches search
                        if (entryName.ToLower().Contains(nameLower))
                        {
                            // add result
                            result.Add(new FruitSearchResult(int.Parse(csvEntry.Entry[0]), entryName));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error searching for fruits");
                }

                return result;
            });    
        }

    }
}
