using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class TxtWriter : IWriter
    {
        public void ListToFile(string fileName, string csvHeaderTemplate, List<string> data)
        {
            using var streamWriter = new StreamWriter(fileName+".txt", true);
            streamWriter.Write(String.Join(';', data));
            streamWriter.Write("\n");
        }
    }
}
