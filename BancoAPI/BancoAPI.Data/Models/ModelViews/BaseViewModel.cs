using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPI.Data.Models.ModelViews
{
    public class BaseViewModel
    {
        public int id { get; set; }
        public string userId { get; set; }
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Updated { get; set; }
    }
}
