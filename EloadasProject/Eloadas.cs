using System;

namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {

            this.foglalasok = new bool[sorokSzama, helyekSzama];
            
        }
    }
}
