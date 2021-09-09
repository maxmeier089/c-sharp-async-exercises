using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FruitStand
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FruitClient fruitClient = new FruitClient();

            while (true)
            {
                try
                {
                    // read search text
                    Console.WriteLine("Enter search text:");
                    string searchText = Console.ReadLine();

                    // search
                    List<Fruit> fruits = await fruitClient.SearchFruits(searchText);


                    // print result
                    foreach (Fruit f in fruits)
                    {
                        Console.WriteLine(f);
                    }

                    Console.WriteLine("\n\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error");
                }

            }
        }
    }
}
