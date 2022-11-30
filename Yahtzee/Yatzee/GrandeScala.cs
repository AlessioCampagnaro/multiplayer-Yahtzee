using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class GrandeScala : ControlloCombinazioni
    {
        // 1,2,3,4,1
        public override int CalcolaValori(int[] array)
        {
            int ris = 0;
            int counter = 0;
            Array.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
                counter++;

                if (array[i] + 1 != array[i + 1])
                {
                    counter = 0;
                }
                if (counter == 4)
                {                  
                    ris = 40;
                }
            }

            return ris;
        }
    }
}
