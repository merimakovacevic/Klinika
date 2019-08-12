using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class VrstaPregleda : InterfejsIspisa
    {
        public string imePregleda { get; private set; }
        public double cijenaPregleda { get; private set; }
        public List<Aparat> potrebniAparati { get; private set; }
        public Ordinacija ordinacija { get; private set; }

        public VrstaPregleda(string ime, double cijena, List<Aparat> lista, Ordinacija ordinacija1)
        {
            imePregleda = ime;
            cijenaPregleda = cijena;
            potrebniAparati = lista;
            ordinacija = ordinacija1;
        }

        public void Ispisi()
        {
            Console.WriteLine("Pregled:");
            Console.WriteLine("    " + imePregleda);
            Console.WriteLine("Cijena:");
            Console.WriteLine("    " + cijenaPregleda);
            Console.WriteLine("Potrebni aparati:");
            foreach(Aparat aparat in potrebniAparati)
            {
                Console.WriteLine("    " + aparat.naziv);
            }
            Console.WriteLine("Ordinacija:");
            Console.WriteLine("    " + ordinacija.imeOrdinacije);
        }
    }


}
