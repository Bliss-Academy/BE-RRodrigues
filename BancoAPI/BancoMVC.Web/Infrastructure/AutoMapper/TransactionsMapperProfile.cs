using AutoMapper;
using BancoAPI.Data.Models.ModelViews;
using BancoAPI.Data.Models;
using BancoAPI.Data.Entities;

namespace BancoMVC.Web.Infrastructure.AutoMapper
{
    public class TransactionsMapperProfile : Profile
    {
        public TransactionsMapperProfile()
        {
            CreateMap<TransactionEntity, TransactionDTO>().ReverseMap();
        }
    }
}