using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Commands.Quotes;

public class CreateQuoteCommand : IRequest<int>
{
    public string Text { get; }
    public int PersonId { get; }

    public CreateQuoteCommand(string text, int personId)
    {
        Text = text;
        PersonId = personId;
    }

    public class CreateQuoteHandler : IRequestHandler<CreateQuoteCommand, int>
    {
        private readonly ICrudService<Quote> _service;
        private readonly IMapper _mapper;

        public CreateQuoteHandler(ICrudService<Quote> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public Task<int> Handle(CreateQuoteCommand command, CancellationToken cancellationToken)
            => _service.CreateAsync(_mapper.Map<Quote>(command), cancellationToken);
    }
}
