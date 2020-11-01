using System;
using System.Linq;
using System.Threading;

namespace Warehouse
{
    class Program
    {

        static Factory[] Factories = new Factory[]
        {
            new Factory() { Capacity = 100 },
            new Factory() { Capacity = 200 },
            new Factory() { Capacity = 50 }
        };

        static Warehouse[] Warehouses = new Warehouse[]
        {
            new Warehouse() { Capacity = 50 },
            new Warehouse() { Capacity = 500 },
            new Warehouse() { Capacity = 250 }
        };


        static void Main(string[] args)
        {
            new Thread(() =>
            {
                Produce();
            }).Start();

            new Thread(() =>
            {
                Produce();
            }).Start();

            new Thread(() =>
            {
                Transport();
            }).Start();

            new Thread(() =>
            {
                Transport();
            }).Start();

            new Thread(() =>
            {
                Buy();
            }).Start();

            new Thread(() =>
            {
                Buy();
            }).Start();
        }

        static void Produce()
        {
            Random random = new Random();

            while (true)
            {
                int index = random.Next(Factories.Count());
                Factory factory = Factories[index];
                factory.CreateProduct();
                Console.WriteLine("Product created in factory " + index);
            }
        }

        static void Transport()
        {
            Random random = new Random();

            while (true)
            {
                int factoryIndex = random.Next(Factories.Count());
                Factory factory = Factories[factoryIndex];

                int warehouseIndex = random.Next(Warehouses.Count());
                Warehouse warehouse = Warehouses[warehouseIndex];

                lock (factory.LockObject)
                {
                    lock (warehouse.LockObject)
                    {
                        if (factory.NumberOfProducts > 0 && warehouse.CapacityLeft > 0)
                        {
                            warehouse.AddProduct(factory.RemoveProduct());
                            Console.WriteLine("Product moved from factory " + factoryIndex + " to ware house " + warehouseIndex);
                        }
                    }
                }
            }
        }

        static void Buy()
        {
            Random random = new Random();

            while (true)
            {
                int warehouseIndex = random.Next(Warehouses.Count());
                Warehouse warehouse = Warehouses[warehouseIndex];
                warehouse.BuyProduct();
                Console.WriteLine("Product bought from warehouse " + warehouseIndex);
            }
        }




    }
}
