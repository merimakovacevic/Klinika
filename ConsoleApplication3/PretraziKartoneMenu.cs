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

        void PretraziKartone()
        {
            Karton karton;
            while (true)
            {
                int id = Utilities.UnesiBroj("Unesite id kartona");
                karton = klinika17600_1.NadjiKarton(id);
                if (karton != null)
                {
                    break;
                }
                Console.WriteLine("Karton za tog pacijenta nije unesen, ili taj pacijent ne postoji.");
            }
            karton.Ispisi();
        }
    }
}
