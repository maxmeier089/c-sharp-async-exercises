using System;
using System.Collections.Generic;
using System.Text;

namespace Warehouse
{
    public class Warehouse
    {

        public int Capacity { get; internal set; } = 100;


        public int CapacityLeft { get => Capacity - Products.Count; }


        internal readonly object LockObject = new object();

        readonly List<Product> Products = new List<Product>();

        readonly Random random = new Random();



        public void AddProduct(Product product)
        {
            lock (LockObject)
            {
                Products.Add(product);
            }
        }

        public void BuyProduct()
        {
            lock (LockObject)
            {
                if (Products.Count > 0)
                {
                    Products.RemoveAt(random.Next(Products.Count - 1));
                }
            }
        }

    }
}
