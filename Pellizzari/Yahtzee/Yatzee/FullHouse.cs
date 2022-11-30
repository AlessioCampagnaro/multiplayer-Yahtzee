using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class FullHouse : ControlloCombinazioni
    {
        // 1,2,1,1,2 -S-O-R-T->  1,1,1,2,2
        // 1,2,2,1,2 -S-O-R-T->  1,1,2,2,2
        // 3,1,5,6,3 -S-O-R-T->  1,3,3,5,6    
        public override int CalcolaValori(int[] array)
        {
            int ris = 0;
            int counter = 0;
            int salvaCounter = 0;
            int counterDisuguaglianze = 0;
            Array.Sort(array);

            for (int i = 0; i < array.Length - 1; i++)
            {
               counter++;
                if (array[i] != array[i + 1])
                {
                    counterDisuguaglianze++;
                    salvaCounter = salvaCounter + counter;
                    counter = 0;
                }
            }

            if ((salvaCounter == 2 || salvaCounter == 3) && counterDisuguaglianze == 1)
            {     
               ris = 25;
            }

            return ris;
        }
    }
}
