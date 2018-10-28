using System;
using Igra;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            
            String IgracJedan = "X";
            string IgracDva = "O";

            Igra.Simbol[,] Polje = new Simbol[3,3];

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Polje[i,j] = new Simbol();
                }
            }

            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    Polje[i,j].Koordinatiziraj(i, j);
                }
            }

            //Test(Polje);

            int BrojPolja;

            while(true)
            {
                ispisiIgru(Polje);
                
                do
                {
                    Console.Write("Igrac 1 (X) - broj polja: ");
                    
                    BrojPolja = Convert.ToInt32(Console.ReadLine());
                }while(zapisiSimbolUIgru(Polje, BrojPolja, IgracJedan) == false);

                if(provjeriZaPobjednika(Polje))
                {
                    Console.Clear();
                    ispisiIgru(Polje);
                    Console.WriteLine("Igrac 1 je pobjednik!");
                    break;
                }

                Console.Clear();

                ispisiIgru(Polje);

                do
                {
                    Console.Write("Igrac 2 (O) - broj polja: ");
                    
                    BrojPolja = Convert.ToInt32(Console.ReadLine());
                }while(zapisiSimbolUIgru(Polje, BrojPolja, IgracDva) == false);

                if(provjeriZaPobjednika(Polje))
                {
                    Console.Clear();
                    ispisiIgru(Polje);
                    Console.WriteLine("Igrac 2 je pobjednik!");
                    break;
                }
                
                Console.Clear();

            }
        }

        static void ispisiIgru(Simbol[,] Polje)
        {
            for(int i = 0; i < 3; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    if(j == 0) Console.Write("   ");
                    Polje[i,j].Prikazi();
                    if(j != 2) Console.Write("     |     ");
                    if(j == 2 && i != 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine("-------------------------------");
                    }                    
                }
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        static bool zapisiSimbolUIgru(Simbol[,] Polje, int Broj, string Simbol)
        {
            int KoordinataX = 0, KoordinataY = 0;

            switch(Broj)
            {
                case 1:
                    break;
                
                case 2:
                    KoordinataX = 0;
                    KoordinataY = 1;
                    break;

                case 3:
                    KoordinataX = 0;
                    KoordinataY = 2;
                    break;

                case 4:
                    KoordinataX = 1;
                    KoordinataY = 0;
                    break;
                
                case 5:
                    KoordinataX = 1;
                    KoordinataY = 1;
                    break;

                case 6:
                    KoordinataX = 1;
                    KoordinataY = 2;
                    break;

                case 7:
                    KoordinataX = 2;
                    KoordinataY = 0;
                    break;
                
                case 8:
                    KoordinataX = 2;
                    KoordinataY = 1;
                    break;
                
                case 9:
                    KoordinataX = 2;
                    KoordinataY = 2;
                    break;
            }

            if(Polje[KoordinataX, KoordinataY].PostaviSimbol(Simbol) == false)
            {
                Console.WriteLine("To polje je vec popunjeno!");
                return false;
            }

            return true;
        }

        static bool provjeriZaPobjednika(Simbol[,] Polje)
        {
            for(int i = 0; i < 3; i++)
            {
                if( Polje[i,0].DohvatiTip() != Tip.Prazno && 
                    Polje[i,0].DohvatiTip() == Polje[i,1].DohvatiTip() &&
                    Polje[i,0].DohvatiTip() == Polje[i,2].DohvatiTip())
                        return true;
            }

            for(int i = 0; i < 3; i++)
            {
                if(Polje[0,i].DohvatiTip() != Tip.Prazno &&
                        Polje[0,i].DohvatiTip() == Polje[1,i].DohvatiTip() &&
                        Polje[0,i].DohvatiTip() == Polje[2,i].DohvatiTip())
                            return true;
            }

            if(Polje[0,0].DohvatiTip() != Tip.Prazno &&
                    Polje[0,0].DohvatiTip() == Polje[1,1].DohvatiTip() &&
                    Polje[0,0].DohvatiTip() == Polje[2,2].DohvatiTip())
                        return true;
                
            if(Polje[2,0].DohvatiTip() != Tip.Prazno &&
                    Polje[2,0].DohvatiTip() == Polje[1,1].DohvatiTip() &&
                    Polje[2,0].DohvatiTip() == Polje[0,2].DohvatiTip())
                        return true;

            return false;
        }

        static void Test(Simbol[,] Polje)
        {
            Polje[1,1].PostaviSimbol("X");
            Polje[0,2].PostaviSimbol("O");
            Polje[2,0].PostaviSimbol("X");
            Polje[2,2].PostaviSimbol("X");
        }
    }
}
