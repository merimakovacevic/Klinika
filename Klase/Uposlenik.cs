namespace ConsoleApplication3
{
    abstract public class Uposlenik : Osoba
    {
        double plata;
        virtual public double IzracunajPlatu(Klinika k, int godina, int mjesec)
        {
            return plata;
        }
        public Uposlenik(string ime, string prezime, double plata) : base(ime, prezime)
        {
            this.plata = plata;
        }
    }
}