using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class Somma : ControlloCombinazioni
    {

         public override int CalcolaValori(int[] array)
        {
            int ris = 0;

            for (int i = 0; i < array.Length; i++)
            {
                ris = ris + array[i];
            }

            return ris;

        }

    }
}
