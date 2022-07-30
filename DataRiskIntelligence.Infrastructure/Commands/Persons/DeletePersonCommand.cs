using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Persons;

public class DeletePersonCommand : IRequest<bool>
{
    private int Id { get; }
    public DeletePersonCommand(int id) => Id = id;

    public class DeletePersonHandler : IRequestHandler<DeletePersonCommand, bool>
    {
        private readonly ICrudService<Person> _service;
        public DeletePersonHandler(ICrudService<Person> service) => _service = service;

        public Task<bool> Handle(DeletePersonCommand command, CancellationToken cancellationToken) => _service.DeleteAsync(command.Id, cancellationToken);
    }
}
