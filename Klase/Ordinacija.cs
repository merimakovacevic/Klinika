using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Ordinacija
    {
        public Ordinacija(string imeOrdinacije, Doktor doktor, List<Aparat> aparati)
        {
            redPacijenataUOrdinaciji = new List<Pacijent>();
            this.aparati = aparati;
            this.doktor = doktor;
            this.imeOrdinacije = imeOrdinacije;
        }
        public List<Pacijent> redPacijenataUOrdinaciji { get; private set; }
        public void DodajPacijentaURed(Pacijent p)
        {
            redPacijenataUOrdinaciji.Add(p);
        }
        public Pacijent UzmiSljedecegPacijenta()
        {
            Pacijent pacijent = redPacijenataUOrdinaciji[0];
            redPacijenataUOrdinaciji.RemoveAt(0);
            return pacijent;
        }
        public Doktor doktor { get; private set; }
        List<Aparat> aparati;
        public string imeOrdinacije { get; private set; }
        public override string ToString()
        {
            return imeOrdinacije;
        }
    }
}
