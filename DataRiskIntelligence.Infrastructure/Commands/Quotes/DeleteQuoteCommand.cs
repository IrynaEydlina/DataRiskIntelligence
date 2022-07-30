using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Quotes;

public class DeleteQuoteCommand : IRequest<bool>
{
    private int Id { get; }
    public DeleteQuoteCommand(int id) => Id = id;

    public class DeleteQuoteHandler : IRequestHandler<DeleteQuoteCommand, bool>
    {
        private readonly ICrudService<Quote> _service;
        public DeleteQuoteHandler(ICrudService<Quote> service) => _service = service;

        public Task<bool> Handle(DeleteQuoteCommand command, CancellationToken cancellationToken) => _service.DeleteAsync(command.Id, cancellationToken);
    }
}
