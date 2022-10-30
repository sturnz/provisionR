using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class SelektionsKeyAuswahlgrafik : IGrafik
    {
        ICsvHeaderFactory CsvHeaderFactory { get; set; }

        public SelektionsKeyAuswahlgrafik(ICsvHeaderFactory csvHeaderFactory)
        {
            CsvHeaderFactory = csvHeaderFactory;
        }

        public string Print(string header)
        {         
            return String.Join("\n", CsvHeaderFactory.GetCsvHeaderList(header));
        }
    }
}
