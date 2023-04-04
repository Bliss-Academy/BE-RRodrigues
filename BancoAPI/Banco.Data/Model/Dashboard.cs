using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data.Model
{
    public class Dashboard
    {
        public decimal balance { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public string name { get; set; }
        public List<string> grafico { get; set; }

    }
}
