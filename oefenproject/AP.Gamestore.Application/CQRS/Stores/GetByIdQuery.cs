using AP.MyGameStore.Application.CQRS.People;
using AP.MyGameStore.Application.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.CQRS.Stores
{
    public class GetByIdQuery : IRequest<StoreDTO>
    {
        public int Id { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, StoreDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<StoreDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            //var person = await uow.PeopleRepository.GetById(request.Id);
            //var personDTO = new PersonDTO()
            //{
            //    Id = person.Id,
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,


            //}
            return mapper.Map<StoreDTO>(await uow.StoresRepository.GetById(request.Id));
        }
    }
}
