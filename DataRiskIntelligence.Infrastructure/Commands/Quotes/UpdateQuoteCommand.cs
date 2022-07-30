using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Quotes;

public class UpdateQuoteCommand : IRequest<bool>
{
    public int Id { get; }
    public string Text { get; }
    public int PersonId { get; }

    public UpdateQuoteCommand(int id, string text, int personId)
    {
        Id = id;
        Text = text;
        PersonId = personId;
    }

    public class UpdateQuoteHandler : IRequestHandler<UpdateQuoteCommand, bool>
    {
        private readonly ICrudService<Quote> _service;
        private readonly IMapper _mapper;

        public UpdateQuoteHandler(ICrudService<Quote> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateQuoteCommand command, CancellationToken cancellationToken)
            => _service.UpdateAsync(_mapper.Map<Quote>(command), cancellationToken);
    }
}
