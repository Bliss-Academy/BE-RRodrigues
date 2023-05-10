using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Models
{
    public class DashboardDTO : BaseDTO
    {   
        public decimal balance { get; set; }
        public decimal income { get; set; }
        public decimal expense { get; set; }
        public string userId { get; set; }
        public string username { get; set; }
        public List<TransactionDTO> timeframedTransactions { get; set; }
        public List<TransactionDTO> lastTransactions { get; set; }
    }
}
