using AutoMapper;
using AutoMapper.Configuration;
using Vidly.Models;
using Vidly_New.Dtos;
using Vidly_New.Models;

namespace Vidly_New.App_Start {

    public class MapperProfile: Profile {

        public MapperProfile() {

            CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Customer, CustomerDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            CreateMap<Movie, MovieDto>();

        

            //var cfg = new MapperConfigurationExpression();
            //    cfg.AddProfile<MapperProfile>();
            //    cfg.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());
            //    cfg.CreateMap<Customer, CustomerDto>();

            //    cfg.CreateMap<MovieDto, Movie>().ForMember(c => c.Id, opt => opt.Ignore());
            //    cfg.CreateMap<Movie, MovieDto>();
            //});
        }
    }
}