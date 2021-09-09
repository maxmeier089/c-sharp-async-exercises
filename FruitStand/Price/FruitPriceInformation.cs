using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStand
{
    public class FruitPriceInformation
    {

        public int ID { get; private set; }

        public decimal Price { get; private set; }

        public FruitPriceInformation(int id, decimal price)
        {
            ID = id;
            Price = price;
        }

    }
}
