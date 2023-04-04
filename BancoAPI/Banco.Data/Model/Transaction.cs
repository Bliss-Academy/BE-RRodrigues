using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Banco.Data.Model
{
    public class Transaction
    {
        public string type { get; set; }
        public decimal value { get; set; }
        public DateTime date { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public Attachment attachment { get; set; }
        public string nomeConta { get; set; }

    }
}
