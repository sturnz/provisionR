using Jasmin1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1
{
    public class Vertragsbestand : IVertragsbestand
    {
        IGrafik Spartenauswahl { get; set; }
        IVertragsfactory Vertragsfactory { get; set; }

        public Vertragsbestand(IGrafik spartenauswahl, IVertragsfactory vertragsfactory)
        {
            Spartenauswahl = spartenauswahl;
            Vertragsfactory = vertragsfactory;
        }

        public void GetVertragBy()
        {
            Console.Clear();
            Console.WriteLine("[Nach welchem Merkmal soll gesucht werden?]\n");
            Console.WriteLine(Spartenauswahl.Print("VertragsHeader"));
            var key = Console.ReadLine();

            Console.WriteLine("\n[Nach welchem Wert soll gesucht werden?]");
            var value = Console.ReadLine();

            foreach (var line in Vertragsfactory.GetVerträge(key, value))
            Console.WriteLine(line);
        }
    }
}
