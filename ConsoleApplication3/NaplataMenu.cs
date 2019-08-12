using ConsoleApplication3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NasaMalaKlinika
{
    partial class Program
    {
        private void Naplata()
        {
            izabrani = Utilities.PretraziPacijenta(klinika17600_1, true);
            MenuManager.NapraviMenuFunkcije("Opcije za racun", new List<string> { "Uplata za danasnji dan", "Uplata prosle rate", "Stanje racuna" }, new List<MenuManager.Selected> { this.Uplata, this.UplataRate, this.StanjeRacuna });
        }

        private void UplataRate()
        {
            double ukupnaCijena = 0;
            Console.WriteLine("Neplacene rate:");
            foreach (Rata rata in izabrani.listaRata)
            {
                if (!rata.jeLiIsplacena())
                {
                    rata.Ispisi();
                    ukupnaCijena += rata.cijenaJedneRate();
                    rata.uplatiRatu();
                }
            }
            Console.WriteLine("Pacijent treba uplatiti: " + ukupnaCijena);
        }

        private void StanjeRacuna()
        {
            Console.WriteLine("Dosadasnja cijena:");
            Console.WriteLine("    " + izabrani.DosadasnjaCijena);
            Console.WriteLine("Dosadasnje rate:");
            foreach (Rata rata in izabrani.listaRata)
            {
                rata.Ispisi();
            }
        }

        private void Uplata()
        {
            if (izabrani.dosadasnjiNeplaceniPregledi.Count == 0)
            {
                Console.WriteLine("Pacijent nema potrebe za placanjem");
                return;
            }
            Console.WriteLine();
            Console.WriteLine("Pacijent treba da plati za sljedece preglede:");
            foreach (VrstaPregleda pregled in izabrani.dosadasnjiNeplaceniPregledi)
            {
                Console.WriteLine();
                pregled.Ispisi();
            }
            Console.WriteLine();
            Console.WriteLine("Pacijent ukupno treba platiti:");
            Console.WriteLine(izabrani.DosadasnjaCijena);
            Console.WriteLine();
            int rate = MenuManager.NapraviMenu("Vrsta placanja", new List<string> { "Na rate", "Gotovinsko" });
            bool nedovoljnaCijena = izabrani.DosadasnjaCijena <= 30;
            if (rate == 0 && !nedovoljnaCijena)
            {
                List<string> brojRataStr = new List<string> { "3", "6", "12" };
                Rata rata;
                double dodatak = 0.15;
                while (true)
                {
                    int brojRataIzbor = MenuManager.NapraviMenu("Broj rata", brojRataStr);
                    int brojRata = int.Parse(brojRataStr[brojRataIzbor]); // 3, 6 ili 12
                    double ukupnaCijena = izabrani.DosadasnjaCijena + izabrani.DosadasnjaCijena * dodatak;
                    if (izabrani.JeLiRedovan())
                    {
                        ukupnaCijena = izabrani.DosadasnjaCijena;
                    }
                    rata = new Rata(ukupnaCijena, brojRata, izabrani.dosadasnjiNeplaceniPregledi);
                    if (rata.cijenaJedneRate() >= 10)
                    {
                        break;
                    }
                    Console.WriteLine("Cijena nije dovoljno velika da se placa na ovoliki broj rata (smanjite rate)");
                }
                rata.Ispisi();
                izabrani.Plati(rata);
            }
            else
            {
                if (nedovoljnaCijena && rate == 0)
                    Console.WriteLine("Cijena nije dovoljno velika da bi se moglo izvrsiti placanje na rate!");
                double ukupnaCijena = izabrani.DosadasnjaCijena;
                if (izabrani.JeLiRedovan())
                {
                    ukupnaCijena = ukupnaCijena - ukupnaCijena * 0.1;
                }
                Console.WriteLine("Pacijent treba platiti " + ukupnaCijena + " KM");
                izabrani.Plati();
            }
        }
    }
}
