using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Persons;

public class UpdatePersonCommand : IRequest<bool>
{
    public int Id { get; }
    public string FirstName { get; }
    public string LastName { get; }

    public UpdatePersonCommand(int id, string firstName, string lastName)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
    }

    public class UpdatePersonHandler : IRequestHandler<UpdatePersonCommand, bool>
    {
        private readonly ICrudService<Person> _service;
        private readonly IMapper _mapper;

        public UpdatePersonHandler(ICrudService<Person> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdatePersonCommand command, CancellationToken cancellationToken)
            => _service.UpdateAsync(_mapper.Map<Person>(command), cancellationToken);
    }
}
