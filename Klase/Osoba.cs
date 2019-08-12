using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    abstract public class Osoba
    {
        public Osoba(string ime, string prezime)
        {
            this.ime = ime;
            this.prezime = prezime;
        }
        string ime { get; set; }
        string prezime { get; set; }
        public string DajImeIPrezime()
        {
            return ime + " " + prezime;
        }
        public override string ToString()
        {
            return DajImeIPrezime();
        }
    }
}
