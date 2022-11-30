using System;
using System.Collections.Generic;
using System.Text;

namespace Yatzee
{
    internal class Dado
    {
        private int num;

        public Dado()
        {
            num = 0;
        }

        public int buttaDado()
        {
            Random n = new Random();
            num = n.Next(1,7);
            return num;
        }

        public int dimmiDado()
        {
            return num;
        }


    }
}
