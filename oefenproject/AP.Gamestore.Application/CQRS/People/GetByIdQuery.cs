using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.CQRS.People
{
    public  class GetByIdQuery : IRequest<PersonDTO>
    {
        public int Id { get; set; }
    }

    public class GetByIdQueryHandler : IRequestHandler<GetByIdQuery, PersonDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetByIdQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<PersonDTO> Handle(GetByIdQuery request, CancellationToken cancellationToken)
        {
            //var person = await uow.PeopleRepository.GetById(request.Id);
            //var personDTO = new PersonDTO()
            //{
            //    Id = person.Id,
            //    FirstName = person.FirstName,
            //    LastName = person.LastName,
                
                
            //}
            return  mapper.Map<PersonDTO>(await uow.PeopleRepository.GetById(request.Id));
        }
    }
}
