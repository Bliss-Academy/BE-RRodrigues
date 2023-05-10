using BancoAPI.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using BancoAPI.Data.Models;
using BancoAPI.Data.Factories;
using BancoAPI.Data.Entities;
using BancoAPI.Business.Services;

namespace BancoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashboardController(IDashboardService dashboardService) { 
            
            _dashboardService = dashboardService;
        }
        
        [HttpGet]
        [Route("getdashboardbyid/{userId}/{timeFrame}")]
        public ActionResult<DashboardDTO> GetDashByUserId(string userId, TimeFrame timeFrame)
            => _dashboardService.GetDashByUserId(userId, timeFrame);


    }
}