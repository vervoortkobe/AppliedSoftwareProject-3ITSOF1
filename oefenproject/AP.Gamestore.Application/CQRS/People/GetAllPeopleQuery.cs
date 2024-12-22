using AP.MyGameStore.Application.Exceptions;
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
    public class GetAllPeopleQuery : IRequest<IEnumerable<PersonDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, IEnumerable<PersonDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllPeopleQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<PersonDTO>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<PersonDTO>>(await uow.PeopleRepository.GetAll(request.PageNr, request.PageSize));
        }
    }

}
