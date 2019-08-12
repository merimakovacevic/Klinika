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
        void RegistrujIliBrisiPacijenta()
        {
            MenuManager.NapraviMenuFunkcije("Registrovati ili brisati pacijenta:",
                new List<string> { "Registrovati novog pacijenta", "Obrisati karton pacijenta" },
                new List<MenuManager.Selected> { this.RegistrujPacijenta, this.ObrisiKarton });
        }

        void ObrisiKarton()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, false);
            izabrani.ObrisiKarton();
        }


        void RegistrujPacijenta()
        {
            Pacijent p = Utilities.NoviPacijent();
            this.klinika17600_1.DodajNovogPacijenta(p);
        }
    }
}
