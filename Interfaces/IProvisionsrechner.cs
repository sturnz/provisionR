﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jasmin1.Interfaces
{
    public interface IProvisionsrechner
    {
        public string BerechneProvision(string sparte, string beitrag, string zahlweise);
    }
}
