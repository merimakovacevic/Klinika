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
        static void Main(string[] args)
        {
            new Program().MainMenu(); 
            // Glavnu logiku programa pravimo u instanciranoj klasi Program, u funkciji MainMenu iz razloga
            // sto je jednostavnije koristiti varijablu klinike iz drugih funkcija, a da smo koristili staticne
            // varijable, imali bi komplikacije poput prosljedjivanja klinike kroz parametre, i druge probleme.
        }

        Klinika klinika17600_1;
        Pacijent izabrani;
        private bool izaci;

        public void MainMenu()
        {
            klinika17600_1 = new Klinika();
            while (izaci == false)
            {
                MenuManager.NapraviMenuFunkcije("Dobro dosli! \n Odaberite jednu od opcija:",
                    new List<string> { "Registruj/brisi pacijenta", "Prikazi raspored pregleda pacijenta", "Kreiranje kartona pacijenta", "Pretraga kartona pacijenta", "Registruj novi pregled", "Analiza sadrzaja", "Naplata", "Izlaz" },
                    new List<MenuManager.Selected> { this.RegistrujIliBrisiPacijenta, this.RasporedPregleda, this.KreirajKarton, this.PretraziKartone, this.OpcijePregleda, this.Analiza, this.Naplata, this.Izlaz });
            }
        }


        void Izlaz()
        {
            izaci = true;
        }
    }
}
