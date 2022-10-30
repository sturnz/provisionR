using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class NeuerKunde : INeuerKunde
    {
        public ICsvHeaderFactory CsvHeaderFactory { get; set; }
        public IWriter CsvWriter { get; set; }
        public string   Datenbank { get; set; }

        public NeuerKunde(ICsvHeaderFactory csvHeaderFactory, IWriter csvWriter, string datenbank)
        {
            CsvHeaderFactory = csvHeaderFactory;
            CsvWriter        = csvWriter;
            Datenbank        = datenbank;
        }

        public List<string> GetKundendaten()
        {
            Console.Clear();
            "neuerkunde".MakeMeABeautifulTitle();

            var listHeader  = CsvHeaderFactory.GetCsvHeaderList("KundenHeader");
            var listData    = new List<string>();

            foreach (var item in listHeader)
            {
                Console.Write($"{item,-12}: ");
                var temp = Console.ReadLine();
                if (temp != "") listData.Add(temp);
            }
            if (listHeader.Count != listData.Count) throw new ArgumentException();
            return listData;
        }

        public void WriteKundenDatenToCsvFile(List<string> list)
        {
            CsvWriter.ListToFile(Datenbank, "KundenHeader", list);

            Console.Write("\nEintrag abgspeichert\n\n");
        }
    }
}
