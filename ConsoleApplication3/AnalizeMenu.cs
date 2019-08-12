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

        private void Analiza()
        {
            MenuManager.NapraviMenuFunkcije("Izaberite vrstu analize:",
                new List<string> { "Izvjestaj plata za tekuci mjesec", "Posjecenost doktora za ovaj mjesec", "Ukupno neizmirenih sredstava od strane pacijenata u klinici" },
                new List<MenuManager.Selected> { this.IzvjestajPlata, this.IzvjestajPosjecenostiDoktora, this.UkupnoNeizmirenihSredstava });
        }

        private void UkupnoNeizmirenihSredstava()
        {
            double ukupno = 0;
            foreach (Pacijent p in klinika17600_1.registrovaniPacijenti)
            {
                foreach (Rata r in p.listaRata)
                {
                    ukupno += r.preostaloZaPlatiti();
                }
            }
            Console.WriteLine("Ukupno neizmirenih sredstava klinici: " + ukupno);
        }

        private void IzvjestajPosjecenostiDoktora()
        {
            foreach (Doktor d in klinika17600_1.doktori)
            {
                Console.WriteLine(d.DajImeIPrezime() + ": " + d.ListaPregledaZaMjesec(klinika17600_1, DateTime.Now.Year, DateTime.Now.Month).Count);
            }
        }

        private void IzvjestajPlata()
        {
            Console.WriteLine("Izvjestaj za doktore:");
            Utilities.IspisiSvePlate(klinika17600_1.doktori, klinika17600_1, DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine();
            Console.WriteLine("Izvjestaj za tehnicare: ");
            Utilities.IspisiSvePlate(klinika17600_1.tehnicari, klinika17600_1, DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine();
            Console.WriteLine("Izvjestaj za cistace: ");
            Utilities.IspisiSvePlate(klinika17600_1.cistaci, klinika17600_1, DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine();
            Console.WriteLine("Izvjestaj za administrativno osoblje: ");
            Utilities.IspisiSvePlate(klinika17600_1.adminOsoblje, klinika17600_1, DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine();
            Console.WriteLine("Izvjestaj za upravu: ");
            Utilities.IspisiSvePlate(klinika17600_1.uprava, klinika17600_1, DateTime.Now.Year, DateTime.Now.Month);
            Console.WriteLine();

        }
    }
}
