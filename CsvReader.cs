using Jasmin1.Interfaces;

namespace Jasmin1
{
    public class CsvReader : IReader
    {
        public List<string> CsvToList(string csvName)
        {
            var lines = new List<string>();

            using (var sr = new StreamReader(csvName))
            {
                while (true)
                {
                    var line = sr.ReadLine();
                    if (line is null) break;
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}
