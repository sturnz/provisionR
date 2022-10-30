using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class CsvWriter : IWriter
    {
        public void ListToFile(string fileName, string csvHeaderTemplate, List<string> data)
        {
            using StreamWriter streamWriter = new StreamWriter(fileName+".csv", true);
            streamWriter.Write(String.Join(';', data));
            streamWriter.Write("\n");
        }
    }
}
