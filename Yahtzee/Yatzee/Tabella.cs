using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Yatzee
{
    internal class Tabella 
    {
        //Pellizzari Nicola 4BI
        private int[] tabella;
        private bool[] TabellaBloccata;
        public Tabella()
        {
            tabella = new int[15];
            TabellaBloccata = new bool[15];
            for (int i = 0; i < TabellaBloccata.Length; i++)
            {
                TabellaBloccata[i] = false;
            }
        }

        public int[] RiempiTabella(int[] dadi)
        {
            //---------------Sezione Primi 6 Valori-------------------------- 0 - 5
            for (int i = 0; i < 6; i++)
            {
                if (!TabellaBloccata[i])
                {
                    tabella[i] = new prime6combinazioni(i + 1).CalcolaValori(dadi);
                }
               
            }
            //----------------------------------------------------------------

            //---------------Sezione Bonus-------------------------- 6
            if (!TabellaBloccata[6])
            {
                int[] primi6valori = new int[] { tabella[0], tabella[1], tabella[2], tabella[3], tabella[4], tabella[5] };
                
                if (primi6valori.Sum() >= 63)
                {
                    tabella[6] = 35;
                }
            }
            //----------------------------------------------------------------

            //---------------Sezione PiccolaScala-------------------------- 7
            if (!TabellaBloccata[7])
            {
                tabella[7] = new PiccolaScala().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------

            //---------------Sezione GrandeScala-------------------------- 8
            if (!TabellaBloccata[8])
            {
                tabella[8] = new GrandeScala().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------

            //---------------Sezione TreDiUnTipo-------------------------- 9
            if (!TabellaBloccata[9])
            {
                tabella[9] = new TreDiUnTipo().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------

            //---------------Sezione QuattroDiUnTipo-------------------------- 10
            if (!TabellaBloccata[10])
            {
                tabella[10] = new QuattroDiUnTipo().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------

            //---------------Sezione FullHouse-------------------------- 11
            if (!TabellaBloccata[11])
            {
                tabella[11] = new FullHouse().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------

            //---------------Sezione Chance-------------------------- 12
            if (!TabellaBloccata[13])
            {
                int somma = 0;
                for (int i = 0; i < dadi.Length; i++)
                {
                    if (!TabellaBloccata[i])
                    {
                        somma = somma + dadi[i];
                    }
                }
                tabella[13] = somma;
            }
            //----------------------------------------------------------------

            //---------------Sezione Yahtzee-------------------------- 13
            if (!TabellaBloccata[12])
            {
                tabella[12] = new Yahtzee().CalcolaValori(dadi);
            }
            //----------------------------------------------------------------
         
            //---------------Sezione TOTALE-------------------------- 14
            if (!TabellaBloccata[14])
            {
                tabella[14] = 0;
                int somma = 0;
                for (int i = 0; i < tabella.Length; i++)
                {
                    if (TabellaBloccata[i])
                    {
                        somma = somma + tabella[i];
                    }
                }
                tabella[14] = somma;
            }

            return tabella;
        }

        public void BloccaCelle(int cellaBloccata)
        {
            TabellaBloccata[cellaBloccata] = true;
        }

        public int[] DammiTabella()
        {
            return tabella;
        }

        public bool ControlloCella(int posizione)
        {
            return TabellaBloccata[posizione];
        }

        public void ResetTabella()
        {
            for (int i = 0; i < tabella.Length - 1; i++)
            {
                if (!TabellaBloccata[i])
                {
                    tabella[i] = 0;
                }
            }
        }

        public int DammiNumBloccate()
        {
            int ris = 0;
            for (int i = 0; i < TabellaBloccata.Length; i++)
            {
                if (TabellaBloccata[i])
                {
                    ris++;
                }
            }
            return ris;
        }

        
    }
}
