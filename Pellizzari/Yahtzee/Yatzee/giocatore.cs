using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Yatzee
{
    internal class Giocatore
    {

        //Pellizzari Nicola 4BI
        private Dado[] dadi;
        private string nome;
        public int punteggio { get; set; }
        private int numDadi;

        public Giocatore(string nome)
        {
            numDadi = 5;
            dadi = new Dado[numDadi];

            for (int i = 0; i < dadi.Length; i++)
            {
                dadi[i] = new Dado();
            }

            this.nome = nome;
            punteggio = 0;
        }

        public int[] tiraDadi(bool[] bloccati)
        {
            int[] ris = new int[numDadi];
            for (int i = 0; i < dadi.Length; i++)
            {
                if (!bloccati[i])
                {
                    ris[i] = dadi[i].buttaDado();
                    Thread.Sleep(50);
                }
                else 
                {
                    ris[i] = dadi[i].dimmiDado();
                }
            }
            return ris;
        }

        public int[] dimmiDadi()
        {
            int[] dadi = new int[5];
            for (int i = 0; i < dadi.Length; i++)
            {
                dadi[i] = this.dadi[i].dimmiDado();
            }
            return dadi;
        }


        public void AumentaPunteggio(int n)
        {
            punteggio = punteggio + n;
        }

      
      
        


    }
}
