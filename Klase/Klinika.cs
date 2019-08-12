using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Klinika
    {
        public List<Ordinacija> ordinacije { get; private set; }
        public List<Doktor> doktori { get; private set; }
        public List<Pacijent> registrovaniPacijenti { get; private set; }
        public List<Tehnicar> tehnicari { get; private set; }
        public List<Cistaci> cistaci { get; private set; }
        public List<Uprava> uprava { get; private set; }
        public List<Osoblje> adminOsoblje { get; private set; }
        public List<VrstaPregleda> sveVrstePregleda { get; private set; }

        public Klinika()
        {
            registrovaniPacijenti = new List<Pacijent>(0);
            doktori = new List<Doktor>();
            ordinacije = new List<Ordinacija>();
            sveVrstePregleda = new List<VrstaPregleda>();
            tehnicari = new List<Tehnicar>();
            cistaci = new List<Cistaci>();
            uprava = new List<Uprava>();
            adminOsoblje = new List<Osoblje>();

            doktori.Add(new Doktor("Doktor 1", "Prezime 1", 700));
            doktori.Add(new Doktor("Doktor 2", "Prezime 2", 1000));
            doktori.Add(new Doktor("Doktor 3", "Prezime 3", 800));
            doktori.Add(new Doktor("Doktor 4", "Prezime 4", 1200));

            Aparat aparat17600_uv = new Aparat("UV Lampa");
            Aparat aparat17600_ekg = new Aparat("EKG");
            Aparat aparat17600_lampa = new Aparat("UV Lampa za polimerizaciju"); //stomatologija
            Aparat aparat17600_rentgenzuba = new Aparat("Rentgen za snimanje zuba");
            Aparat aparat17600_rtg = new Aparat("RTG aparat"); //stomatologija
            Aparat aparat17600_dermatoskop = new Aparat("Dermatoskop");
            Aparat aparat17600_laserfoto = new Aparat("Laserski koagulator"); //oftalmologija
            Aparat aparat17600_slitlamp = new Aparat("Slit lamp sa digitalnom kamerom"); //oftalmologija
            Aparat aparat17600_lensometar = new Aparat("Auto lensometar sa ekranom u boji"); //oftalmologija
            Aparat aparat17600_ultrazvuk = new Aparat("Ultrazvucni aparat"); //kardiologija

            Ordinacija ordinacija17600_dermatologija = new Ordinacija("Dermatologija", doktori[0], new List<Aparat> { aparat17600_uv, aparat17600_dermatoskop });
            Ordinacija ordinacija17600_kardiologija = new Ordinacija("Kardiologija", doktori[1], new List<Aparat> { aparat17600_ekg, aparat17600_ultrazvuk });
            Ordinacija ordinacija17600_stomatologija = new Ordinacija("Stomatologija", doktori[2], new List<Aparat> { aparat17600_rtg, aparat17600_lampa, aparat17600_rentgenzuba });
            Ordinacija ordinacija17600_oftamologija = new Ordinacija("Oftamologija", doktori[3], new List<Aparat> { aparat17600_lensometar, aparat17600_slitlamp });

            ordinacije.Add(ordinacija17600_dermatologija);
            ordinacije.Add(ordinacija17600_kardiologija);
            ordinacije.Add(ordinacija17600_stomatologija);
            ordinacije.Add(ordinacija17600_oftamologija);

            registrovaniPacijenti.Add(new Pacijent("Ana", "Anic", new DateTime(1994, 11, 21), "2111994014980", "y", "neudata", "Mustafe Pintola br 10"));
            registrovaniPacijenti.Add(new Pacijent("Sebija", "Sebic", new DateTime(1990, 04, 01), "0104996170014", "z", "udata", "Titova br 100"));
            registrovaniPacijenti.Add(new Pacijent("Adi", "Adic", new DateTime(1991, 05, 10), "1005991170014", "m", "ozenjen", "Ferhadija br 125"));
            registrovaniPacijenti.Add(new Pacijent("Hari", "Haric", new DateTime(1980, 01, 27), "2701980123800", "m", "neozenjen", "Semira Fraste br 6"));

            sveVrstePregleda.Add(new VrstaPregleda("Pregled zuba", 20, new List<Aparat> { }, ordinacija17600_stomatologija));
            sveVrstePregleda.Add(new VrstaPregleda("Hitan slucaj", 0, new List<Aparat> { }, null));
            sveVrstePregleda.Add(new VrstaPregleda("Mjerenje pritiska", 20, new List<Aparat> { }, ordinacija17600_kardiologija));
            sveVrstePregleda.Add(new VrstaPregleda("EKG pregled", 30, new List<Aparat> { aparat17600_ekg }, ordinacija17600_kardiologija));
            sveVrstePregleda.Add(new VrstaPregleda("Dermatoloski obicni pregled", 20, new List<Aparat> { }, ordinacija17600_dermatologija));
            sveVrstePregleda.Add(new VrstaPregleda("Dermatoloski napredni pregled", 30, new List<Aparat> { aparat17600_uv }, ordinacija17600_dermatologija));
            sveVrstePregleda.Add(new VrstaPregleda("Pregled ocnog pritiska", 20, new List<Aparat> { }, ordinacija17600_oftamologija));

            sveVrstePregleda.Add(new VrstaPregleda("Pregled zuba za vozacki ispit/prijavu na konkurs", 10, new List<Aparat> { }, ordinacija17600_stomatologija));
            sveVrstePregleda.Add(new VrstaPregleda("EKG pregled za vozacki ispit/prijavu na konkurs", 15, new List<Aparat> { aparat17600_ekg }, ordinacija17600_kardiologija));
            sveVrstePregleda.Add(new VrstaPregleda("Pregled ocnog pritiska za vozacki ispit/prijavu na konkurs", 10, new List<Aparat> { }, ordinacija17600_oftamologija));
            sveVrstePregleda.Add(new VrstaPregleda("Dermatoloski obicni pregled za prijavu na konkurs", 10, new List<Aparat> { }, ordinacija17600_dermatologija));
        }

        public List<VrstaPregleda> vratiListuPregledaPoOrdinacijama(Ordinacija ordinacija)
        {
            List<VrstaPregleda> vratiti = new List<VrstaPregleda>();
            foreach(VrstaPregleda vrsta in sveVrstePregleda)
            {
                if (vrsta.ordinacija == ordinacija)
                {
                    vratiti.Add(vrsta);
                }
            }
            return vratiti;
        }

        public VrstaPregleda PretraziVrstuPregleda(string naziv)
        {
            foreach(VrstaPregleda vrsta in sveVrstePregleda)
            {
                if (vrsta.imePregleda.ToLower() == naziv.ToLower()) return vrsta;
            }
            return null;
        }

        public void DodajNovogPacijenta(Pacijent p)
        {
            registrovaniPacijenti.Add(p);
        }

        public List<Pacijent> NadjiPacijente(string pretraga)
        {
            List<Pacijent> pacijenti = new List<Pacijent>();
            foreach(Pacijent pacijent in registrovaniPacijenti)
            {
                if (pacijent.DajImeIPrezime().ToLower().Contains(pretraga.ToLower()))
                {
                    pacijenti.Add(pacijent);
                }
            }
            return pacijenti;
        }

        public Karton NadjiKarton(int id)
        {
            foreach(Pacijent pacijent in registrovaniPacijenti)
            {
                if (pacijent.ID == id && pacijent.karton != null)
                {
                    return pacijent.karton;
                }
            }
            return null;
        }
    }
}
