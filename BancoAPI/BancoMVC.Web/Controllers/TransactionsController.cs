using Microsoft.AspNetCore.Mvc;
using BancoAPI.Data.Models.ModelViews;
using System.Diagnostics;

namespace BancoMVC.Web.Controllers
{
    public class TransactionsController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public TransactionsController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("Transactions");
        }

        public IActionResult AdicionarIncome()
        {
            return View("AddIncome");
        }

        public IActionResult AdicionarExpense()
        {
            return View("AddExpense");
        }

        public IActionResult EditarTransaction()
        {
            return View("EditTransaction");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
