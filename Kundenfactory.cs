using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class Kundenfactory : IKundenfactory
    {
        IReader Reader { get; set; }

        public Kundenfactory(IReader reader)
        {
            Reader = reader;
        }
        public IEnumerable<string> GetKunden()
        {
            var kundendaten = Reader.CsvToList("Kundendaten.csv");
            foreach (var line in kundendaten)
            {
                var elements = line.Split(';');
                yield return (String.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|{7,-15}|{8,-15}|",
                                                elements.ElementAt(0),
                                                elements.ElementAt(1),
                                                elements.ElementAt(2),
                                                elements.ElementAt(3),
                                                elements.ElementAt(4),
                                                elements.ElementAt(5),
                                                elements.ElementAt(6),
                                                elements.ElementAt(7),
                                                elements.ElementAt(8)));
            }
        }

        public IEnumerable<string> GetKunden(string key, string value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));

            var kundendaten = Reader.CsvToList("Kundendaten.csv");
            var selektion = new List<string>();

            if (value == null)
            {
                selektion = kundendaten;
            }

            var list = kundendaten[0].Split(';').ToList();
            int index = list.IndexOf(key);
            
            selektion = kundendaten.Where(x => x.Split(';').ElementAt(index) == value).ToList();

            foreach (var line in selektion)
            {
                var elements = line.Split(';');
                yield return (String.Format("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|{7,-15}|{8,-15}|",
                                                elements.ElementAt(0),
                                                elements.ElementAt(1),
                                                elements.ElementAt(2),
                                                elements.ElementAt(3),
                                                elements.ElementAt(4),
                                                elements.ElementAt(5),
                                                elements.ElementAt(6),
                                                elements.ElementAt(7),
                                                elements.ElementAt(8)));
            }
        }
    }
}
