using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStand
{
    public class Fruit
    {

        public int ID { get; private set; }

        public string Name { get; private set; }

        public string Description { get; internal set; }

        public decimal Price { get; internal set; }

        public override string ToString()
        {
            return "ID: " + ID + " Name: " + Name + " Description: " + Description + " Price: " + Price;
        }

        public Fruit(int id, string name)
        {
            ID = id;
            Name = name;
        }

    }
}
