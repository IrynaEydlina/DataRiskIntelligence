using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Domain.Extensions;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Commands.Quotes;

namespace DataRiskIntelligence.Infrastructure.MappingProfiles;

public class QuoteProfile : Profile
{
    public QuoteProfile()
    {
        CreateMap<Quote, QuoteDto>()
            .ForMember(x => x.PersonName, x => x.MapFrom(src => src.Person.GetFullName()));

        CreateMap<CreateQuoteCommand, Quote>()
            .ForPath(x => x.Person.Id, x => x.MapFrom(src => src.PersonId));

        CreateMap<UpdateQuoteCommand, Quote>()
            .ForPath(x => x.Person.Id, x => x.MapFrom(src => src.PersonId));
    }
}
