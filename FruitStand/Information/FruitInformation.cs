using System;
using System.Collections.Generic;
using System.Text;

namespace FruitStand
{
    public class FruitInformation
    {

        public int ID { get; private set; }

        public string Description { get; private set; }

        public FruitInformation(int id, string description)
        {
            ID = id;
            Description = description;
        }

    }
}
