using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpCity.Models
{
    public class Bank
    {
        public Guard Guard { get; set; }

        public Gate Gate { get; set; }

        public Vault Vault { get; set; }

        public List<Lazor> Lazors { get; set; }

        public List<Safe> SafeList { get; set; }
    }
}
