using CSVReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStand
{
    public class Price
    {

        public async Task<List<FruitPriceInformation>> GetPrice(List<int> fruitIDs)
        {
            return await Task.Run(async () =>
            {
                // create result list
                List<FruitPriceInformation> result = new List<FruitPriceInformation>();

                try
                {
                    // read CSV entries
                    CSVReader.CSVReader reader = new CSVReader.CSVReader();

                    List<CSVEntry> csvEntries = await reader.ReadFile("Fruit Price.CSV");

                    foreach (CSVEntry csvEntry in csvEntries)
                    {
                        // parse ID
                        int id = int.Parse(csvEntry.Entry[0]);

                        // check if ID was requested
                        if (fruitIDs.Contains(id))
                        {
                            // add price
                            result.Add(new FruitPriceInformation(id, decimal.Parse(csvEntry.Entry[1])));
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error getting fruit prices");
                }

                return result;
            });
        }

    }
}
