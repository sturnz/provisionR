namespace Jasmin1.Interfaces
{
    public interface INeuerKunde
    {
        IWriter CsvWriter { get; set; }

        List<string> GetKundendaten();
        void WriteKundenDatenToCsvFile(List<string> list);
    }
}