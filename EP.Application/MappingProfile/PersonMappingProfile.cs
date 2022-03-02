using AutoMapper;
using EP.Application.Cites;
using EP.Application.People;
using EP.Application.States;
using EP.Domain.City;
using EP.Domain.Person;
using EP.Domain.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EP.Application.MappingProfile
{
    public class PersonMappingProfile : Profile
    {
        public PersonMappingProfile()
        {
            CreateMap<GetPersonDto, Person>();

            CreateMap<Person, GetPersonDto>()
                .ForMember(c => c.IranStateName, x => x.MapFrom(p => p.IranState.Name))
                .ForMember(c => c.IranCityName, x => x.MapFrom(p => p.IranCity.Name));

            CreateMap<IranState, StateDto>().ReverseMap();
            CreateMap<IranCity, CitesDto>().ReverseMap();

            CreateMap<Person, PersonDto>();
            CreateMap<GetPersonDto, PersonDto>();
        }
    }
}
