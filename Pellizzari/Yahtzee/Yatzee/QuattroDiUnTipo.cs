using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class QuattroDiUnTipo : ControlloCombinazioni
    {
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
                if (counter == 3)
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
