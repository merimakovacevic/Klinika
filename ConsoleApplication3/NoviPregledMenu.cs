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

        void OpcijePregleda()
        {
            MenuManager.NapraviMenuFunkcije("Registruj novi pregled", new List<string> { "Dodaj novi pregled", "Izvrsi pregled pacijenta" },
                new List<MenuManager.Selected> { this.DodajNoviPregled, this.IzvrsiPregled });

        }

        private void IzvrsiPregled()
        {
            Ordinacija ordinacija = Utilities.PretraziOrdinaciju(klinika17600_1);
            if (ordinacija.redPacijenataUOrdinaciji.Count == 0)
            {
                Console.WriteLine("Nema pacijanata u redu u ovoj ordinaciji");
                return;
            }
            Pacijent izabran = ordinacija.UzmiSljedecegPacijenta();
            VrstaPregleda vrsta = izabran.trenutniPregledi[0];
            Console.WriteLine("Sljedeci pacijent je: " + izabran.DajImeIPrezime());
            Console.WriteLine("Pacijent treba da izvrsi sljedeci pregled:");
            vrsta.Ispisi();
            Doktor doktor = vrsta.ordinacija.doktor;
            string anamneza = Utilities.UnesiString("Unesite anamnezu za pregled");
            Pregled pregled = new Pregled(anamneza, izabran.trenutniPregledi[0], doktor);
            izabran.Pregledaj(pregled);
        }

        void DodajNoviPregled()
        {
            MenuManager.NapraviMenuFunkcije("Izaberi vrstu pregleda", new List<string> { "Hitni slucaj", "Regularni pregled", "Pregled za vozacki ispit", "Pregled za prijavu na konkurs" },
            new List<MenuManager.Selected> { this.HitanPregled, this.RegularniPregled, this.VozackiPregled, this.KonkursPregled });
        }

        private void HitanPregled()
        {
            string anamneza = Utilities.UnesiString("Unesite opis hitnog slucaja ukljucujuci i informacije o eventualnoj smrti (vrijeme smrti i preliminarni uzrok smrti, kao i vrijeme u koje se zakazuje obdukcija ako je to potrebno)");
            Doktor doktor = Utilities.PretraziDoktora(klinika17600_1);
            Pregled pregled = new Pregled(anamneza, klinika17600_1.PretraziVrstuPregleda("hitan slucaj"), doktor);
            Pacijent p = Utilities.PretraziPacijentaIliKreiraj(klinika17600_1);
            if (p.karton == null)
            {
                Console.WriteLine("Pacijent nije imao karton te se automatski generisao");
                p.DodajKarton(new Karton("DOSAO NA HITAN PREGLED", "Nema informacija", p));
            }
            p.PregledajBezPlacanja(pregled);
        }

        private void VozackiPregled()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, true);
            izabrani.DodajNovePreglede(new List<VrstaPregleda>
            {
                klinika17600_1.PretraziVrstuPregleda("pregled zuba za vozacki ispit/prijavu na konkurs"),
                klinika17600_1.PretraziVrstuPregleda("ekg pregled za vozacki ispit/prijavu na konkurs"),
                klinika17600_1.PretraziVrstuPregleda("pregled ocnog pritiska za vozacki ispit/prijavu na konkurs")
            });
        }

        private void KonkursPregled()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, true);
            izabrani.DodajNovePreglede(new List<VrstaPregleda>
            {
                klinika17600_1.PretraziVrstuPregleda("pregled zuba za vozacki ispit/prijavu na konkurs"),
                klinika17600_1.PretraziVrstuPregleda("dermatoloski obicni pregled za prijavu na konkurs"),
                klinika17600_1.PretraziVrstuPregleda("ekg pregled za vozacki ispit/prijavu na konkurs"),
                klinika17600_1.PretraziVrstuPregleda("pregled ocnog pritiska za vozacki ispit/prijavu na konkurs")
            });
        }

        void RegularniPregled()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, true);
            List<string> listaOpcija = new List<string>();
            foreach (Ordinacija ord in klinika17600_1.ordinacije)
            {
                listaOpcija.Add(ord.imeOrdinacije);
            }
            int izbor = MenuManager.NapraviMenu("Izaberite ordinaciju: ", listaOpcija);
            Ordinacija izabrana = klinika17600_1.ordinacije[izbor];
            listaOpcija.Clear();
            List<VrstaPregleda> lista = klinika17600_1.vratiListuPregledaPoOrdinacijama(izabrana);
            foreach (VrstaPregleda vrsta in lista)
            {
                listaOpcija.Add(vrsta.imePregleda);
            }
            izbor = MenuManager.NapraviMenu("Izaberite pregled: ", listaOpcija);
            izabrani.DodajNovePreglede(new List<VrstaPregleda> { lista[izbor] });
        }
    }
}
