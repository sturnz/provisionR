namespace Jasmin1.Interfaces
{
    public interface IKundenfactory
    {
        IEnumerable<string> GetKunden();
        IEnumerable<string> GetKunden(string key, string value);
    }
}