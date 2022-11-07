using System;
using System.Configuration;
using System.Collections.Specialized;
using Jasmin1.Interfaces;
using System.Linq.Expressions;

namespace Jasmin1
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string provisionsanteil;
            string datenbankKunden;
            string datenbankVerträge;

            if (args.Contains("-h")) { HilfePrinter.Print(); return; }

            else
            {
                var cr      = new CommandLineHandler();
                var dict    = cr.Read(args);

                if (!cr.CheckFormat(dict))  throw new Exception("Arguments are invalid!");
                if (!cr.CheckKeys(dict))    throw new Exception("Keys are invalid!");
                //if (!cr.CheckValues(dict))  throw new Exception("Values are invalid!");

                provisionsanteil  = dict.ContainsKey("-pa")  ? dict["-pa"]  : ConfigurationManager.AppSettings.Get("Provisionsanteil");
                datenbankKunden   = dict.ContainsKey("-dak") ? dict["-dak"] : ConfigurationManager.AppSettings.Get("DatenbankKunden");
                datenbankVerträge = dict.ContainsKey("-dav") ? dict["-dav"] : ConfigurationManager.AppSettings.Get("DatenbankVerträge");

            }


            ICsvHeaderFactory    csvHeaderFactory    = new CsvHeaderFactory();
            IProvisionsrechner   provisionsrechner   = new Provisionsrechner(Int32.Parse(provisionsanteil));
            IWriter              writer              = new CsvWriter();
            IReader              reader              = new CsvReader();
            INeuerVertrag        neuerVertrag        = new NeuerVertrag(csvHeaderFactory, provisionsrechner, writer, datenbankVerträge);
            INeuerKunde          neuerKunde          = new NeuerKunde(csvHeaderFactory, writer, datenbankKunden);
            IInitialisierung     initialisierung     = new Initialisierung(csvHeaderFactory);
            IGrafik              grafik              = new Auswahlgrafik();
            IGrafik              spartengrafik       = new SelektionsKeyAuswahlgrafik(csvHeaderFactory);
            IVertragsfactory     vertragsfactory     = new Vertragsfactory(reader);
            IKundenfactory       kundenfactory       = new Kundenfactory(reader);
            IKundenstamm        kundenstamm         = new Kundenstamm(spartengrafik, kundenfactory);
            IBusinessLogik       businessLogik       = new BusinessLogik(neuerKunde, neuerVertrag, reader, vertragsfactory, kundenfactory, spartengrafik, kundenstamm, datenbankKunden);



            if (!initialisierung.DatabaseExists()) initialisierung.MakeDatabase();

            while (true)
            {
                Console.WriteLine(grafik.Print("¯\\_(ツ)_/¯") + "\n\nDeine Auswahl: ");
                businessLogik.HandleChoice(Console.ReadLine());
            }
        }
    }
}
