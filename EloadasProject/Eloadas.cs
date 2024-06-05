using System;

namespace EloadasProject
{
    public class Eloadas
    {
        private bool[,] foglalasok;

        public Eloadas(int sorokSzama, int helyekSzama)
        {

            if (sorokSzama <= 0 || helyekSzama <= 0)
            {
                throw new ArgumentException("A sorok és helyek számának nagyobbnak kell lennie 0-nál.");
            }
            this.foglalasok = new bool[sorokSzama, helyekSzama];
        }

        // Metódus a foglalások lekérdezésére
        public bool CheckLefoglalva(int sor, int hely)
        {
            return foglalasok[sor, hely];
        
        // Metódus egy hely foglalásához
        /*
        public void Foglal(int sor, int hely)
        {
            foglalasok[sor, hely] = true;
        }
        */
        // Metódus egy hely felszabadításához
        public void Felszabadit(int sor, int hely)
        {
            foglalasok[sor, hely] = false;
        
        
        public bool LefoglalElsoSzabad()
        
            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        foglalasok[i, j] = true;
                        return true;
                    }
                }
            }
            return false;
        
        public int SzabadHelyek { get {
            int szabadHelyekSzama = 0;
            for (int i = 0; i < foglalasok.GetLength(0); i++)
            {
                for (int j = 0; j < foglalasok.GetLength(1); j++)
                {
                    if (!foglalasok[i, j])
                    {
                        szabadHelyekSzama++;
                    }
                }
            }
            return szabadHelyekSzama;
            }
        
        public bool Teli
        {
            get
            {
                for (int i = 0; i < foglalasok.GetLength(0); i++)
                {
                    for (int j = 0; j < foglalasok.GetLength(1); j++)
                    {
                        if (!foglalasok[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        
        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam <= 0 || helySzam <= 0 || sorSzam > foglalasok.GetLength(0) || helySzam > foglalasok.GetLength(1))
            {
                throw new ArgumentException("Érvénytelen sor vagy helyszám.");
            }
            return foglalasok[sorSzam - 1, helySzam - 1];
        }
    
    }
}
