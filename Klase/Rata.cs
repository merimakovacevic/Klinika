using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Rata : InterfejsIspisa
    {
        public double Total { get; private set; }
        public int BrojRata { get; private set; }
        public int UplacenihRata { get; private set; }
        public string Opis { get; private set; }
        public Rata(double total, int brojRata, List<VrstaPregleda> pregledi)
        {
            // Lambda izraz je koristen da pretvorimo pregled u string.
            // Lambda funkcija je pozvana na svaki element niza pregledi
            string[] preglediStr = pregledi.Select(pregled => pregled.imePregleda).ToArray();
            Opis = string.Join(", ", preglediStr);
            Total = total;
            BrojRata = brojRata;
            uplatiRatu();
        }
        public void uplatiRatu()
        {
            if (UplacenihRata < BrojRata)
            {
                UplacenihRata++;
            }
        }
        public bool jeLiIsplacena()
        {
            return UplacenihRata == BrojRata;
        }
        public double cijenaJedneRate()
        {
            return Total / (double)BrojRata;
        }
        public int brojPreostalihRata()
        {
            return BrojRata - UplacenihRata;
        }
        public double preostaloZaPlatiti()
        {
            return cijenaJedneRate() * (double)brojPreostalihRata();
        }

        public void Ispisi()
        {
            Console.WriteLine("Opis rate:");
            Console.WriteLine("    " + Opis);
            Console.WriteLine("Ukupna cijena:");
            Console.WriteLine("    " + Total);
            Console.WriteLine("Cijena rate:");
            Console.WriteLine("    " + cijenaJedneRate());
            Console.WriteLine("Preostalo za platiti:");
            Console.WriteLine("    " + preostaloZaPlatiti());
            Console.WriteLine("Broj rata:");
            Console.WriteLine("    " + BrojRata);
            Console.WriteLine("Broj preostalih rata");
            Console.WriteLine("    " + brojPreostalihRata());
        }
    }
}
