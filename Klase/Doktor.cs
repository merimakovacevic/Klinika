using System.Collections.Generic;

namespace ConsoleApplication3
{
    public sealed class Doktor : Uposlenik
    {
        public Doktor(string ime, string prezime, double plata) : base(ime, prezime, plata)
        {
        }

        public List<Pregled> ListaPregledaZaMjesec(Klinika k, int godina, int mjesec)
        {
            List<Pregled> pregledi = new List<Pregled>();
            foreach (Pacijent pacijent in k.registrovaniPacijenti)
            {
                if (pacijent.karton != null)
                {
                    foreach (Pregled pregled in pacijent.karton.dosadasnjiPregledi)
                    {
                        if (pregled.doktor == this
                            && pregled.datumPregleda.Month == mjesec
                            && pregled.datumPregleda.Year == godina)
                        {
                            pregledi.Add(pregled);
                        }
                    }
                }
            }
            return pregledi;
        }
        public override double IzracunajPlatu(Klinika k, int godina, int mjesec)
        {
            int[] poDanu = new int[40];
            List<Pregled> pregledi = ListaPregledaZaMjesec(k, godina, mjesec);
            foreach (Pregled pregled in pregledi)
            {
                if (poDanu[pregled.datumPregleda.Day] < 20)
                {
                    poDanu[pregled.datumPregleda.Day]++;
                }
            }
            double ukupanBonus = 0;
            double bonusNaPacijenta = 10;
            foreach(int uDanu in poDanu)
            {
                ukupanBonus += (double)uDanu * bonusNaPacijenta;
            }
            return base.IzracunajPlatu(k, godina, mjesec) + ukupanBonus;
        }
    }
}