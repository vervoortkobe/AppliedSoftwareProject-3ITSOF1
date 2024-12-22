using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.CQRS.Stores;
using AP.MyGameStore.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Person, PersonDTO>();
            CreateMap<Person, PersonDetailDTO>().ReverseMap();
            CreateMap<Store, StoreDTO>();

        }
    }
}
