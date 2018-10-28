namespace Igra
{
    enum Tip: byte
    {
        Krizic = 1,
        Kruzic = 2,
        Prazno = 3
    }

    class Simbol
    {
        private int PozicijaX, PozicijaY;

        Tip TipSimbola;

        public Simbol()
        {
            this.TipSimbola = Tip.Prazno;
        }

        public void Koordinatiziraj(int _X, int _Y)
        {
            PozicijaX = _X;
            PozicijaY = _Y;
        }

        public Tip DohvatiTip()
        {
            return this.TipSimbola;
        }

        public void Prikazi()
        {
            if(this.TipSimbola == Tip.Krizic)
            {
                System.Console.Write("X");
            }
            
            if(this.TipSimbola == Tip.Kruzic)
            {
                System.Console.Write("O");
            }

            if(this.TipSimbola == Tip.Prazno)
            {
                System.Console.Write(" ");
            }
        }

        public void PostaviSimbol(string Simbol)
        {
            if(Simbol == "X")
            {
                this.TipSimbola = Tip.Krizic;
            }

            if(Simbol == "O")
            {
                this.TipSimbola = Tip.Kruzic;
            }      
        }
    }
}