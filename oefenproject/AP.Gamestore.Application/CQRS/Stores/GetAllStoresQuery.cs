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
using static AP.MyGameStore.Application.Interfaces.IStoresRepository;

namespace AP.MyGameStore.Application.CQRS.Stores
{
    public class GetAllStoresQuery : IRequest<IEnumerable<StoreDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public SortBy SortBy { get; set; }
    }
    public class GetAllStoresQueryHandler : IRequestHandler<GetAllStoresQuery, IEnumerable<StoreDTO>>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public GetAllStoresQueryHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<StoreDTO>> Handle(GetAllStoresQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<StoreDTO>>(await uow.StoresRepository.GetAll(null, request.SortBy, request.PageNr, request.PageSize));
        }
    }
}
