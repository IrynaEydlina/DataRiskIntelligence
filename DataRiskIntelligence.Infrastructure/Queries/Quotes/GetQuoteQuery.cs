using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Queries.Quotes;

public class GetQuoteQuery : IRequest<List<QuoteDto>>
{
    public class GetQuoteHandler : IRequestHandler<GetQuoteQuery, List<QuoteDto>>
    {
        private readonly ICrudService<Quote> _service;
        private readonly IMapper _mapper;

        public GetQuoteHandler(ICrudService<Quote> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<List<QuoteDto>> Handle(GetQuoteQuery request, CancellationToken cancellationToken)
        {
            var quotes = await _service.GetAllAsync(cancellationToken);

            return _mapper.Map<List<QuoteDto>>(quotes);
        }
    }
}
