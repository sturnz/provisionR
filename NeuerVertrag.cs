using Jasmin1.Interfaces;

namespace Jasmin1
{
    internal class NeuerVertrag : INeuerVertrag
    {
        ICsvHeaderFactory   CsvHeaderFactory    { get; set; }
        IProvisionsrechner  Provisionsrechner   { get; set; }
        IWriter             FileWriter          { get; set; }
        string              Datenbank           { get; set; }

        public NeuerVertrag(ICsvHeaderFactory   csvHeaderFactory, 
                            IProvisionsrechner  provisionsrechner, 
                            IWriter             csvWriter,
                            string              datenbank)
        {
            CsvHeaderFactory    = csvHeaderFactory;
            Provisionsrechner   = provisionsrechner;
            FileWriter          = csvWriter;
            Datenbank           = datenbank;
        }

        public void GetVertragsdaten()
        {
            Console.Clear();
            "neuervertrag".MakeMeABeautifulTitle();

            var listHeader      = CsvHeaderFactory.GetCsvHeaderList("VertragsHeader");
            var vertragsdaten   = new List<string>();

            foreach (var item in listHeader.SkipLast(1))
            {
                Console.Write($"{item,-17}: ");
                var userInput = Console.ReadLine();
                if (userInput != "") vertragsdaten.Add(userInput);
            }
            if (listHeader.Count - 1 != vertragsdaten.Count) throw new ArgumentException();
            vertragsdaten = GetProvision(vertragsdaten);
            WriteVertragsDatenToFile(vertragsdaten);
        }

        public List<string> GetProvision(List<string> list)
        {
            var provision = Provisionsrechner.BerechneProvision(list[^3], list[^2], list[^1]);

            list.Add(provision);
            Console.WriteLine($"{"Provision",-17}: {provision} Euro");
            return list;
        }
        public void WriteVertragsDatenToFile(List<string> list)
        {
            FileWriter.ListToFile(Datenbank, "VertragsDaten", list);

            Console.WriteLine("\nEintrag abgspeichert");
        }
    }
}
