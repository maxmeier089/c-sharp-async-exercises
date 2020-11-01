using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Warehouse
{
    public class Factory
    {

        public int Capacity { get; internal set; } = 100;


        public int CapacityLeft { get => Capacity - Products.Count; }

        public int NumberOfProducts { get => Products.Count; }


        internal readonly object LockObject = new object();

        readonly List<Product> Products = new List<Product>();

        readonly Random random = new Random();



        public void CreateProduct()
        {
            lock (LockObject)
            {
                if (CapacityLeft > 0)
                {
                    Products.Add(new Product());
                }
            }
        }

        public Product RemoveProduct()
        {
            lock (LockObject)
            {
                if (Products.Count > 0)
                {
                    int index = random.Next(Products.Count);
                    Product product = Products.ElementAt(index);
                    Products.RemoveAt(index);
                    return product;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
