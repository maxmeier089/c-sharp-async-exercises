using CSVReader;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FruitStand
{
    public class Product
    {

        public async Task<List<FruitInformation>> GetInformation(List<int> fruitIDs)
        {
            // create result list
            List<FruitInformation> result = new List<FruitInformation>();

            try
            {
                // read CSV entries
                CSVReader.CSVReader reader = new CSVReader.CSVReader();

                List<CSVEntry> csvEntries = await reader.ReadFile("Fruit Product.CSV");

                foreach (CSVEntry csvEntry in csvEntries)
                {
                    // parse ID
                    int id = int.Parse(csvEntry.Entry[0]);

                    // check if ID was requested
                    if (fruitIDs.Contains(id))
                    {
                        // add information
                        result.Add(new FruitInformation(id, csvEntry.Entry[1]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting fruit information");
            }

            return result;
        }

    }
}
