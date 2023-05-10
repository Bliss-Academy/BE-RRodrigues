using BancoAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BancoAPI.Data.Models
{
    public class TransactionDTO : BaseDTO
    {
        public string userId { get; set; }
        public TrasactionType type { get; set; }
        public decimal value { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string attachment { get; set; }

    }
}
