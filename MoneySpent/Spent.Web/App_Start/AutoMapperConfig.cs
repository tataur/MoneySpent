using AutoMapper;
using Spent.DAL;
using Spent.Web.Models;

namespace Spent.Web.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<MoneyEntity, MoneyModel>());
        }
    }
}