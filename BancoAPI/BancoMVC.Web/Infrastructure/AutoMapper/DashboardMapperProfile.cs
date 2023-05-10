using AutoMapper;
using BancoAPI.Data.Models;
using BancoAPI.Data.Models.ModelViews;

namespace BancoMVC.Web.Infrastructure.AutoMapper
{
    public class DashboardMapperProfile : Profile
    {
        public DashboardMapperProfile() {
            CreateMap<DashboardDTO, DashboardViewModel>().ReverseMap();
        }
    }
}
