using AP.MyGameStore.Application.Exceptions;
using AP.MyGameStore.Application.Interfaces;
using AP.MyGameStore.Domain;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AP.MyGameStore.Application.CQRS.People
{
    public class AddCommand : IRequest<PersonDetailDTO>
    {
        public PersonDetailDTO Person { get; set; }
    }

    public class AddCommandValidator : AbstractValidator<AddCommand>
    {
        private IUnitofWork uow;

        public AddCommandValidator(IUnitofWork uow)
        {
            this.uow = uow;

            RuleFor(s => s.Person.FirstName)
                .NotNull()
                .WithMessage("Firstname cannot be empty");

            RuleFor(s => s.Person.FirstName)
                .MaximumLength(15)
                .WithMessage("Firstname is too long");
            
            RuleFor(s => s.Person.EmployerId)
                .MustAsync(async (id, cancellation) =>
                {
                    var employer = await uow.StoresRepository.GetById(id);
                    return (employer != null);
                })
                .WithMessage("The specified employer does not exist");
        }
    }
    public class AddCommandHandler : IRequestHandler<AddCommand, PersonDetailDTO>
    {
        private readonly IUnitofWork uow;
        private readonly IMapper mapper;

        public AddCommandHandler(IUnitofWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        public async Task<PersonDetailDTO> Handle(AddCommand request, CancellationToken cancellationToken)
        {
            //var employer = await uow.StoresRepository.GetById(request.Person.EmployerId);
            //if (employer == null)
            //    throw new RelationNotFoundException("The specified employer does not exist");

            await uow.PeopleRepository.Create(mapper.Map<Person>(request.Person));
            await uow.Commit();
            return request.Person;
        }
    }
}
