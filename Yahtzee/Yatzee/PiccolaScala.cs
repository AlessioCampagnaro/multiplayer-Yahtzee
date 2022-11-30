using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Yatzee
{
    internal class PiccolaScala : ControlloCombinazioni
    {
        // 1,2,3,4,1
        public override int CalcolaValori(int[] array)
        {
            int ris = 0;
            int counter = 0;
            int i = 0;
            int j = 0;
            Array.Sort(array);                                                                      //  1,2,2,3,4                                                                                      

            while (i < array.Length - 1)
            {
                if (array[i] + 1 == array[j])
                {
                    counter++;
                    i = j;
                }

                if (j == array.Length - 1)
                {
                    i++;
                    j = i;
                }
                j++;
            }

            if (counter > 3)
            {
                ris = 30;
            }

            return ris;
        }
    }
}
