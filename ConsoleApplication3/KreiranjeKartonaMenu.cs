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
        void KreirajKarton()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, false);
            string napomene = Utilities.UnesiString("Unesite bitne napomene o pacijentu: alergije, vakcinacije i prosle bolesti");
            string prosleBolesti = Utilities.UnesiString("Unesite listu proslih bolesti");
            Karton karton = new Karton(napomene, prosleBolesti, izabrani);
            izabrani.DodajKarton(karton);
        }
    }
}
