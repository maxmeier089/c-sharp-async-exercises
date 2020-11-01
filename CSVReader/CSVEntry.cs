using System;
using System.Collections.Generic;
using System.Text;

namespace CSVReader
{
    public class CSVEntry
    {

        public string[] Entry { get; internal set; }

        public override string ToString()
        {
            string returnString = "";

            foreach (string s in Entry)
            {
                returnString += s + " ";
            }

            return returnString;
        }

    }
}
