using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Queries.Quotes;

public class GetQuoteyIdQuery : IRequest<QuoteDto>
{
    private int Id { get; }

    public GetQuoteyIdQuery(int id) => Id = id;

    public class GetQuoteyIdHandler : IRequestHandler<GetQuoteyIdQuery, QuoteDto>
    {
        private readonly ICrudService<Quote> _service;
        private readonly IMapper _mapper;

        public GetQuoteyIdHandler(ICrudService<Quote> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<QuoteDto> Handle(GetQuoteyIdQuery request, CancellationToken cancellationToken)
        {

            var quote = await _service.GetByIdAsync(request.Id, cancellationToken);
            if (quote == null)
            {
                return null;
            }

            return _mapper.Map<QuoteDto>(quote);
        }
    }
}
