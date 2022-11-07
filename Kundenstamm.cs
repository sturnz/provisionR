using Jasmin1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1
{
    public class Kundenstamm : IKundenstamm
    {
        IGrafik Spartenauswahl { get; set; }
        IKundenfactory Kundenfactory { get; set; }
        public Kundenstamm(IGrafik spartenauswahl,
                                IKundenfactory kundenfactory)
        {
            Spartenauswahl = spartenauswahl;
            Kundenfactory = kundenfactory;
        }
        public void GetKundeBy()  // todo: Returnwert und Parameter einbauen 
        {

            Console.Clear();
            Console.WriteLine("[Nach welchem Merkmal soll gesucht werden?]\n");
            Console.WriteLine(Spartenauswahl.Print("KundenHeader"));
            var key = Console.ReadLine();

            Console.WriteLine("\n[Nach welchem Wert soll gesucht werden?]");
            var value = Console.ReadLine();

            if (key == "" && value == "")
            {
                foreach (var line in Kundenfactory.GetKunden())
                    Console.WriteLine(line);
            }
            else
            {
                foreach (var line in Kundenfactory.GetKunden(key, value))
                    Console.WriteLine(line);
            }
        }


    }
}
