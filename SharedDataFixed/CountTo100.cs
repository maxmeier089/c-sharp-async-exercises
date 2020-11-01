using System;
using System.Collections.Generic;
using System.Text;

namespace SharedDataFixed
{
    public class CountTo100
    {

        public int Number { get; set; } = 0;


        private bool up = true;


        private readonly object lockObject = new object();


        public void NextNumber()
        {
            lock (lockObject)
            {
                if (up)
                {
                    Number++;
                }
                else
                {
                    Number--;
                }

                if (Number == 100) up = false;
                else if (Number == 0) up = true;
            }
        }


    }
}
