using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace DataRiskIntelligence.Infrastructure.Queries.Quotes;

public class GeDayQuoteQuery : IRequest<QuoteDto>
{
    public class GeDayQuoteHandler : IRequestHandler<GeDayQuoteQuery, QuoteDto>
    {
        private readonly ICrudService<Quote> _service;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;

        public GeDayQuoteHandler(ICrudService<Quote> service, IMapper mapper, IMemoryCache memoryCache)
        {
            _service = service;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        public async Task<QuoteDto> Handle(GeDayQuoteQuery request, CancellationToken cancellationToken)
        {
            var key = DateTime.Now.Date.ToString();

            if (_memoryCache.TryGetValue<QuoteDto>(key, out var quoteDto))
            {
                return quoteDto;
            }

            var quotes = await _service.GetAllAsync(cancellationToken);
            if (quotes.Count == 0)
            {
                return null;
            }

            var random = new Random();
            var index = random.Next(quotes.Count);

            var expireAt = new TimeSpan(23 - DateTime.Now.Hour, 59 - DateTime.Now.Minute, 59 - DateTime.Now.Second);

            return _memoryCache.Set(key, _mapper.Map<QuoteDto>(quotes[index]), expireAt);
        }
    }
}
