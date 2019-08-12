using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Karton : InterfejsIspisa
    {
        public List<Pregled> dosadasnjiPregledi { get; private set; }
        public string listaProslihBolesti { get; private set; }
        public string napomene { get; private set; }
        public Pacijent pacijent { get; private set; }
        public Karton(string napomene, string prosleBolesti, Pacijent pacijent)
        {
            this.napomene = napomene;
            listaProslihBolesti = prosleBolesti;
            this.pacijent = pacijent;
            dosadasnjiPregledi = new List<Pregled>();
        }

        public void Ispisi()
        {
            pacijent.Ispisi();
            Console.WriteLine();
            Console.WriteLine("Karton pacijenta");
            Console.WriteLine();
            Console.WriteLine("Lista proslih bolesti: ");
            Console.WriteLine("    " + listaProslihBolesti);
            Console.WriteLine("Napomene:");
            Console.WriteLine("    " + napomene);
            Console.WriteLine("Dosadasnji pregledi u klinici:");
            foreach(Pregled pregled in dosadasnjiPregledi)
            {
                Console.WriteLine();
                pregled.Ispisi();
            }
        }
    }
}
