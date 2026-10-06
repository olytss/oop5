using oop3.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace oop3.interfaces
{
    internal interface IPcRepository
    {
     IEnumerable<PC> pcList { get;  set; }
    public PC getPcById(int PCid, IEnumerable<PC> pcList, out string message);

    }
}
