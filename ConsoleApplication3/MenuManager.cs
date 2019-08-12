using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    public class MenuManager
    {
        public delegate void Selected();
        // Delegat selected je funkcija koja se treba pozvati kada se izabere neki od prikazanih opcija u meni-u
        // Funkcija NapraviMenuFunkcije prima listu delegata, i pozove odgovarajuci delegat na osnovu izabrane
        // opcije u meni-u. Na ovaj nacin jednostavno proslijedimo listu funkcija koje se trebaju pozvati, umjesto
        // da koristimo dugi switch ili if/else statement, te time skratimo i olaksamo koristenje meni-a.
        public static void NapraviMenuFunkcije(string naslov, List<string> opcije, List<Selected> funkcije)
        {
            try
            {
                funkcije[NapraviMenu(naslov, opcije)]();
            } catch (Exception e)
            {
                Console.WriteLine("Desila se greska: " + e.Message);
            }
        }
        public static int NapraviMenu(string naslov, List<string> opcije)
        {
            Console.WriteLine(naslov);
            for (int i = 0; i < opcije.Count; i++)
            {
                Console.Write((i + 1) + ": ");
                Console.WriteLine(opcije[i]);
            }
            while (true)
            {
                try
                {
                    int izbor = int.Parse(Console.ReadLine());
                    if (izbor >= 1 && izbor <= opcije.Count)
                    {
                        return izbor - 1;
                    }
                }
                catch (Exception)
                {

                }
                Console.WriteLine("Molimo unesite broj izmedju 1 i " + opcije.Count);
            }
        }
    }
}
