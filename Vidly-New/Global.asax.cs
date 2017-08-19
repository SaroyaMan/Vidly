using AutoMapper;
using System;
using System.Data.Entity;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Vidly.Models;
using Vidly_New.Dtos;

namespace Vidly_New
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto, Customer>();
                //cfg.CreateMap<Customer, CustomerDto>().ForMember(c => c.Id, opt => opt.Ignore());

                cfg.CreateMap<Movie, MovieDto>();
                cfg.CreateMap<MovieDto, Movie>();
                //cfg.CreateMap<Movie, MovieDto>().ForMember(m => m.Id, opt => opt.Ignore());

            });

            GlobalConfiguration.Configure(WebApiConfig.Register);
            Database.SetInitializer<Models.ApplicationDbContext>(null);
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            Vidly.RouteConfig.RegisterRoutes(RouteTable.Routes);
            Vidly.BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
