using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.Models;
using Vidly_New.App_Start;
using Vidly_New.Dtos;

namespace Vidly_New
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var cfg = new MapperConfigurationExpression();
            //cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //cfg.CreateMap<Customer, CustomerDto>();

            //cfg.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            //cfg.CreateMap<Movie, MovieDto>();

            Mapper.Initialize(cfg => {
                cfg.AddProfile<MapperProfile>();    
                    
            //    cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //    cfg.CreateMap<Customer, CustomerDto>();

            //    cfg.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            //    cfg.CreateMap<Movie, MovieDto>(););
            });


            //MapperConfig.InitMapper();

            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<Models.ApplicationDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Vidly.RouteConfig.RegisterRoutes(RouteTable.Routes);
            Vidly.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
