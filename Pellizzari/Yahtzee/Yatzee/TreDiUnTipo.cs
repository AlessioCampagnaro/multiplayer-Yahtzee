using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class TreDiUnTipo : ControlloCombinazioni
    {
        //3-2-3-3-1  -S-O-R-T-> 1-2-3-3-3
        //1-2-1-1-4  -S-O-R-T-> 1-1-1-2-4
        //5-2-5-5-6  -S-O-R-T-> 2-5-5-5-6
        public override int CalcolaValori(int[] array) 
        {
            int ris = 0;
            int counter = 0;
            bool check = false;
            Array.Sort(array);

            for (int i = 0; i < array.Length - 1 && !check; i++)
            {
                counter++;
                if (array[i] != array[i + 1])
                {
                    counter = 0;
                }
                if (counter == 2)
                {
                    check = true;
                }
            }

            if (check)
            {
                Somma c = new Somma();
               ris = c.CalcolaValori(array);
            }

            return ris;
        }
    }
}
