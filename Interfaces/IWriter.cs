using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1.Interfaces
{
    public interface IWriter
    {
        public void ListToFile(string fileName, string csvHeaderTemplate, List<string> data);
    }
}
