using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using System.Windows.Forms.VisualStyles;

namespace Yatzee
{
    internal class prime6combinazioni : ControlloCombinazioni
    {
        private int n;

        public prime6combinazioni (int inN) // numero da ricercare e sommare
        {
            n = inN;            
        }

        //Pellizzari Nicola 4BI

        public override int CalcolaValori(int[] dadi)
        {
            int ris = 0;
         
            for (int i = 0; i < 5 ; i++)  // 1 1 1 5 5
            {
                if (dadi[i] == n)
                {
                    ris = ris + n;
                }
            }

            return ris;
        }

    }
}
