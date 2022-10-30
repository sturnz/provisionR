namespace Jasmin1.Interfaces
{
    internal interface INeuerVertrag
    {
        List<string> GetProvision(List<string> list);
        void GetVertragsdaten();
        void WriteVertragsDatenToFile(List<string> list);
    }
}