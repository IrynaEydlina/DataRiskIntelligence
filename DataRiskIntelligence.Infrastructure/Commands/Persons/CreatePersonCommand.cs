using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Persons;

public class CreatePersonCommand : IRequest<int>
{
    public string FirstName { get; }
    public string LastName { get; }

    public CreatePersonCommand(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, int>
    {
        private readonly ICrudService<Person> _service;
        private readonly IMapper _mapper;

        public CreatePersonHandler(ICrudService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<int> Handle(CreatePersonCommand command, CancellationToken cancellationToken)
            => _service.CreateAsync(_mapper.Map<Person>(command), cancellationToken);
    }
}
