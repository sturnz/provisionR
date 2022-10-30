using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class CsvHeaderFactory : ICsvHeaderFactory
    {
        private readonly List<string> kundenHeader = new List<string>()
        {
            "KNR",
            "Anrede",
            "Nachname",
            "Vorname",
            "Geburtsdatum",
            "Strasse",
            "Stadt",
            "Festnetz",
            "Mobil",
        };

        private readonly List<string> vertragsHeader = new List<string>()
        {
            "KNR",
            "Nachname",
            "Vorname",
            "VNR",
            "Datum",
            "Sparte",
            "Beitrag",
            "Zahlweise",
            "Provision Partner",
        };

        public List<string> GetCsvHeaderList(string type)
        {
            switch (type)
            {
                case "KundenHeader":
                    return kundenHeader;
                case "VertragsHeader":
                    return vertragsHeader;
                default:
                    return null;
            }
        }
    }
}
