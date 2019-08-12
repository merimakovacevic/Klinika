using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Pacijent : Osoba, InterfejsIspisa
    {
        public Int32 ID { get; private set; }
        public Karton karton { get; private set; }
        DateTime datumRodjenja { get; set; }
        string maticni { get; set; }
        string spol { get; set; }
        string adresaStanovanja { get; set; }
        string bracnoStanje { get; set; }
        DateTime datumPrijema { get; set; }
        public List<VrstaPregleda> trenutniPregledi { get; private set; }
        public double DosadasnjaCijena { get; private set; }
        public List<VrstaPregleda> dosadasnjiNeplaceniPregledi { get; private set; }
        public List<Rata> listaRata { get; private set; }

        public Pacijent (string ime1, string prezime1, DateTime datum1, string maticni1, string spol1, string bracnos, string adresa): base(ime1, prezime1)
        {
            ID = IDManager.dajNoviID();
            spol = spol1;
            bracnoStanje = bracnos;
            adresaStanovanja = adresa;
            datumRodjenja = datum1;
            datumPrijema = DateTime.Now;
            maticni = maticni1;
            trenutniPregledi = new List<VrstaPregleda>();
            listaRata = new List<Rata>();
            dosadasnjiNeplaceniPregledi = new List<VrstaPregleda>();
        }

        public void DodajKarton(Karton k)
        {
            karton = k;
        }

        public void Ispisi()
        {
            Console.WriteLine();
            Console.WriteLine("Pacijent");
            Console.WriteLine();
            Console.WriteLine("Broj kartona:");
            Console.WriteLine("    " + ID);
            Console.WriteLine("Ime i prezime pacijenta:");
            Console.WriteLine("    " + DajImeIPrezime());
            Console.WriteLine("Spol:");
            Console.WriteLine("    " + spol);
            Console.WriteLine("Datum rodjenja:");
            Console.WriteLine("    " + Klase.Utilities.formatiranDatum(datumRodjenja));
            Console.WriteLine("Maticni broj:");
            Console.WriteLine("    " + maticni);
            Console.WriteLine("Datum i vrijeme prijema:");
            Console.WriteLine("    " + Klase.Utilities.formatiranoVrijeme(datumPrijema));
            Console.WriteLine("Bracno stanje:");
            Console.WriteLine("    " + bracnoStanje);
            Console.WriteLine("Adresa stanovanja:");
            Console.WriteLine("    " + adresaStanovanja);
        }

        public void ObrisiKarton()
        {
            karton = null;
        }

        public void DodajNovePreglede(List<VrstaPregleda> vrste)
        {
            foreach (VrstaPregleda vrsta in vrste)
            {
                foreach (Aparat aparat in vrsta.potrebniAparati)
                {
                    if (!aparat.uFunkciji)
                    {
                        Console.WriteLine("Aparat " + aparat.naziv + " nije u funkciji, te pregled " + vrsta.imePregleda + " nije moguce obaviti");
                        return;
                    }
                }
            }
            foreach (VrstaPregleda vrsta in vrste)
            {
                if (trenutniPregledi.Count == 0)
                {
                    vrsta.ordinacija.DodajPacijentaURed(this);
                }
                trenutniPregledi.Add(vrsta);
            }
        }

        public void Pregledaj(Pregled pregled)
        {
            this.karton.dosadasnjiPregledi.Add(pregled);
            this.dosadasnjiNeplaceniPregledi.Add(pregled.vrsta);
            this.trenutniPregledi.Remove(pregled.vrsta);
            DosadasnjaCijena += pregled.vrsta.cijenaPregleda;
            if (trenutniPregledi.Count > 0)
            {
                trenutniPregledi[0].ordinacija.DodajPacijentaURed(this);
            }
        }

        public void PregledajBezPlacanja(Pregled pregled)
        {
            this.karton.dosadasnjiPregledi.Add(pregled);
        }

        public void Plati()
        {
            DosadasnjaCijena = 0;
            dosadasnjiNeplaceniPregledi.Clear();
        }

        public void Plati(Rata rata)
        {
            Plati();
            listaRata.Add(rata);
        }

        public bool JeLiRedovan()
        {
            return karton.dosadasnjiPregledi.Count > 3;
        }
    }
}
