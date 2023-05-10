using BancoAPI.Business.Services;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BancoMVC.Web.Controllers
{
    public class DashboardController : Controller {

        private readonly IDashboardService _dashboardService;
        private readonly ITransactionService _transactionService;
        private readonly IModelViewFactory _modelViewFactory;

        public DashboardController(IDashboardService dashboardservice, ITransactionService transactionService, IModelViewFactory modelViewFactory)
        {
            _dashboardService = dashboardservice;
            _transactionService = transactionService;
            _modelViewFactory = modelViewFactory;
        }

        public IActionResult Index()
        {
            var model = _dashboardService.MVGetDashByUserId("1", TimeFrame.weekly);
            return View(model);
        }
          
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
