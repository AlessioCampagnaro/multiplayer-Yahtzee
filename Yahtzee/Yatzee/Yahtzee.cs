using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class Yahtzee : ControlloCombinazioni
    {
        public override int CalcolaValori(int[] array)
        {
            int ris = 0;
            int counter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {
                
                if (array[i] == array[i + 1])
                {
                    counter++;                
                }
            }

            if (counter == array.Length - 1)
            {
                
                ris = 50;
            }

            return ris;
        }
    }
}
