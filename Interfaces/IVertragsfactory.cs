namespace Jasmin1.Interfaces
{
    public interface IVertragsfactory
    {
        IEnumerable<string> GetVerträge();
        IEnumerable<string> GetVerträge(string key, string value);
    }
}