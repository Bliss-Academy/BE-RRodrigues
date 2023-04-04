using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Banco.Data.Model;

namespace Banco.Data.Interface
{
    public interface IDashboard
    {
        Dashboard GetDash(string id);
    }
}
