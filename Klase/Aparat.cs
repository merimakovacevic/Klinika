using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public sealed class Aparat
    {
        public Aparat(string naziv, bool ispravan = true)
        {
            this.naziv = naziv;
            uFunkciji = ispravan;
        }
        public bool uFunkciji { get; private set; }
        public string naziv { get; private set; }
    }
}
