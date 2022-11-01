using Jasmin1.Interfaces;

namespace Jasmin1
{
    internal class BusinessLogik : IBusinessLogik
    {
        INeuerKunde         NeuerKunde          { get; set; }
        INeuerVertrag       NeuerVertrag        { get; set; }
        IReader             Reader              { get; set; }
        IVertragsfactory    Vertragsfactory     { get; set; }
        IKundenfactory      Kundenfactory       { get; set; }
        IGrafik             Spartenauswahl      { get; set; }
        string              Datenbank           { get; set; }

        public BusinessLogik( INeuerKunde        neuerKunde, 
                              INeuerVertrag      neuerVertrag, 
                              IReader            reader, 
                              IVertragsfactory   vertragsfactory, 
                              IKundenfactory     kundenfactory,
                              IGrafik            spartenauswahl,
                              string             datenbank)
        {
            NeuerKunde      = neuerKunde;
            NeuerVertrag    = neuerVertrag;
            Reader          = reader;
            Vertragsfactory = vertragsfactory;
            Kundenfactory   = kundenfactory;
            Spartenauswahl  = spartenauswahl;
            Datenbank       = datenbank;
        }

        public void HandleChoice( string choice )
        {
            if      (choice == "1")
            {
                var DatenListe = NeuerKunde.GetKundendaten();
                NeuerKunde.WriteKundenDatenToCsvFile(DatenListe);
            }
            else if (choice == "2")
            {
                NeuerVertrag.GetVertragsdaten();
            }
            else if (choice == "3")
            {
                Console.Clear();
                Console.WriteLine("[Nach welchem Merkmal soll gesucht werden?]\n");
                Console.WriteLine(Spartenauswahl.Print("KundenHeader"));
                var key = Console.ReadLine();

                Console.WriteLine("\n[Nach welchem Wert soll gesucht werden?]");
                var value = Console.ReadLine();

                if(key == "" && value == "")
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
            else if(choice == "4")
            {
                Console.Clear();
                Console.WriteLine("[Nach welchem Merkmal soll gesucht werden?]\n");
                Console.WriteLine(Spartenauswahl.Print("VertragsHeader"));
                var key     = Console.ReadLine();

                Console.WriteLine("\n[Nach welchem Wert soll gesucht werden?]");
                var value   = Console.ReadLine();
                    
                foreach(var line in Vertragsfactory.GetVerträge(key, value))
                    Console.WriteLine(line); 
            }
        }
    }
}
