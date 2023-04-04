using Banco.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.Data.Interface;

namespace Banco.Data.Repository
{   
    public class DashboardRepository : IDashboard
    {
        List<Dashboard> lisDash = new List<Dashboard>
        {
            new Dashboard{balance=1, income=500, expense=100, name="Kirtesh" },
            new Dashboard{balance=2, income=1500, expense=200, name="Nitya" },
            new Dashboard{balance=3, income=2000, expense=200, name="Dilip" },
            new Dashboard{balance=4, income=3000, expense=300, name="Atul" },
            new Dashboard{balance=5, income=4500, expense=400, name="Swati" },
            new Dashboard{balance=6, income=5000, expense=2000, name="Rashmi" },
        };



        public Dashboard GetDash(string id)
        {
            return lisDash.FirstOrDefault(x => x.name == id);
        }
    }
}
