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

        private void RasporedPregleda()
        {
            Pacijent izabrani = Utilities.PretraziPacijenta(klinika17600_1, false);
            foreach (VrstaPregleda pregled in izabrani.trenutniPregledi)
            {
                Console.WriteLine();
                pregled.Ispisi();
            }
        }
    }
}
