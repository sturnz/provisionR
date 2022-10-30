using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using Jasmin1.Interfaces;

namespace Jasmin1
{

    public class Initialisierung : IInitialisierung
    {
        ICsvHeaderFactory CsvHeaderFactory { get; set; }

        static string fileNameKundendaten   = "Kundendaten";
        static string fileNameVertragsdaten = "Vertragsdaten";

        public Initialisierung(ICsvHeaderFactory csvHeaderFactory)
        {
            CsvHeaderFactory = csvHeaderFactory;
        }

        public bool DatabaseExists()
        {
            if (File.Exists(fileNameKundendaten))
            {
                Console.WriteLine($"Datenbank -- {fileNameKundendaten} -- existiert und wird genutzt.");
                Console.WriteLine($"Datenbank -- {fileNameVertragsdaten} -- existiert und wird genutzt.");
                return true;
            }

            return false;
        }

        public void MakeDatabase()
        {
            var headerKundendaten   = CsvHeaderFactory.GetCsvHeaderList("KundenHeader");
            var headerVertragsdaten = CsvHeaderFactory.GetCsvHeaderList("VertragsHeader");

            var temp = File.Create(fileNameKundendaten);
            temp.Close();
            using var sw = new StreamWriter(fileNameKundendaten, true);
            sw.Write(String.Join(';', headerKundendaten));
            sw.Write("\n");

            var temp2 = File.Create(fileNameVertragsdaten);
            temp2.Close();
            using var ssw = new StreamWriter(fileNameVertragsdaten, true);
            ssw.Write(String.Join(';', headerVertragsdaten));
            ssw.Write("\n");

            Console.WriteLine($"Datenbank -- {fileNameKundendaten} -- wurde angelegt und wird genutzt.");       // todo : Dateityp als Konsolenargument übergeben
            Console.WriteLine($"Datenbank -- {fileNameVertragsdaten} -- wurde angelegt und wird genutzt.");     // todo : Dateityp als Konsolenargument übergeben
        }
    }
}
