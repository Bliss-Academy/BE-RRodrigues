using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
    }
}
