using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Utilities
    {

        public static string formatiranDatum(DateTime d)
        {
            return d.Day + "/" + d.Month + "/" + d.Year;
        }

        public static string formatiranoVrijeme(DateTime d)
        {
            return d.Day + "/" + d.Month + "/" + d.Year + " " + d.Hour + ":" + d.Minute;
        }
    }
}
