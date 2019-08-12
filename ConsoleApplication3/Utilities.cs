using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Utilities
    {
        public static bool TacanMaticniBroj(string maticni, DateTime datumRodjenja)
        {
            int danMat, mjesecMat, godMat;
            if (maticni.Length != 13) return false;
            danMat = Convert.ToInt32(maticni.Substring(0, 2));
            mjesecMat = Convert.ToInt32(maticni.Substring(2, 2));
            godMat = Convert.ToInt32(maticni.Substring(4, 3));
            int test = Convert.ToInt32(maticni.Substring(7, 6));
            if (danMat == datumRodjenja.Day && mjesecMat == datumRodjenja.Month && datumRodjenja.Year%1000 == godMat)
                return true;
            else return false;

        }

        public static string UnesiString(string zaIspis)
        {
            Console.WriteLine(zaIspis + ": ");
            return Console.ReadLine();
        }

        public static DateTime UnesiDatum(string zaIspis)
        {
            Console.WriteLine(zaIspis + ": ");
            while (true)
            {
                try
                {
                    return DateTime.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Datum nije ispravan, unesite ponovo");
                }
            }
        }

        public static int UnesiBroj(string zaIspis)
        {
            Console.WriteLine(zaIspis + ": ");
            while (true)
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Broj nije ispravan, unesite ponovo");
                }
            }
        }

        public static Pacijent PretraziPacijentaIliKreiraj(Klinika k)
        {
            int izbor = MenuManager.NapraviMenu("Izaberi pacijenta", new List<string> { "Novi pacijent", "Pretraga pacijenta" });
            if (izbor == 0)
            {
                Pacijent p = NoviPacijent();
                k.DodajNovogPacijenta(p);
                return p;
            } else
            {
                return PretraziPacijenta(k, false);
            }
        }

        public static double IspisiSvePlate<T>(List<T> lista, Klinika k, int godina, int mjesec) where T: Uposlenik
        {
            double ukupno = 0;
            foreach (Uposlenik uposlenik in lista)
            {
                double plata = uposlenik.IzracunajPlatu(k, godina, mjesec);
                ukupno += plata;
                Console.WriteLine(uposlenik.DajImeIPrezime() + ": " + plata);
            }
            return ukupno;
        }

        public static Pacijent NoviPacijent()
        {

            string ime = Utilities.UnesiString("Unesite ime");
            string prezime = Utilities.UnesiString("Unesite prezime");
            DateTime datumRodjenja = Utilities.UnesiDatum("Unesite datum rođenja u formatu dan/mjesec/godina");
            string maticniBroj;
            Console.WriteLine("Unesite maticni broj:");
            while (true)
            {
                try
                {
                    maticniBroj = Console.ReadLine();
                    if (Utilities.TacanMaticniBroj(maticniBroj, datumRodjenja))
                    {
                        break;
                    }
                }
                catch (Exception)
                {

                }
                Console.WriteLine("Maticni broj nije pravilan");
            }
            string spol = Utilities.UnesiString("Unesite spol (muski/zenski)");
            string bracnoStanje = Utilities.UnesiString("Unesite bracno stanje");
            string adresa = Utilities.UnesiString("Unesite adresu stanovanja");
            Pacijent p = new Pacijent(ime, prezime, datumRodjenja, maticniBroj, spol, bracnoStanje, adresa);
            return p;
        }

        public static Pacijent PretraziPacijenta(Klinika k, bool samoSaKartonom)
        {
            Pacijent izabrani = PretraziUListi<Pacijent>(k.registrovaniPacijenti,
                "Unesite ime/prezime za pretrazivanje pacijenta", "Nije ni jedan pacijent pronadjen sa datim imenom/prezimenom", "Izaberite pacijenta");
            Console.WriteLine("Izabrani pacijent: " + izabrani.DajImeIPrezime());
            if (izabrani.karton == null && samoSaKartonom)
            {
                throw new Exception("Karton pacijenta ne postoji");
            }
            return izabrani;
        }

        public static Doktor PretraziDoktora(Klinika k)
        {
            Doktor izabrani = PretraziUListi<Doktor>(k.doktori,
                "Unesite ime/prezime za pretrazivanje doktora", "Nije ni jedan doktor pronadjen sa datim imenom/prezimenom", "Izaberite doktora");
            Console.WriteLine("Izabrani doktor: " + izabrani.DajImeIPrezime());
            return izabrani;
        }

        public static Ordinacija PretraziOrdinaciju(Klinika k)
        {
            Ordinacija ordinacija = PretraziUListi<Ordinacija>(k.ordinacije,
                "Unesite ime ordinacije za pretrazivanje", "Nije pronadjena ordinacija sa datim imenom", "Izaberite ordinaciju");
            Console.WriteLine("Izabrana ordinacija: " + ordinacija.imeOrdinacije);
            return ordinacija;
        }

        public static T PretraziUListi<T>(List<T> lista, string naslov, string errorNijePronadjen, string menuNaslov)
        {
            T izabrani;
            while(true)
            {
                string ime = (lista.Count < 5) ? "" : UnesiString(naslov);
                List<T> kandidati = new List<T>();
                foreach (T osoba in lista)
                {
                    if (osoba.ToString().ToLower().Contains(ime.ToLower()))
                    {
                        kandidati.Add(osoba);
                    }
                }
                if (kandidati.Count == 1)
                {
                    izabrani = kandidati[0];
                    break;
                }
                if (kandidati.Count == 0)
                {
                    Console.WriteLine(errorNijePronadjen);
                } else
                {
                    List<string> imenaPacijenata = new List<string>();
                    for (int i=0; i<kandidati.Count; i++)
                    {
                        imenaPacijenata.Add(kandidati[i].ToString());
                    }
                    izabrani = kandidati[MenuManager.NapraviMenu(menuNaslov, imenaPacijenata)];
                    break;
                }
            }
            return izabrani;
        }
    }
}
