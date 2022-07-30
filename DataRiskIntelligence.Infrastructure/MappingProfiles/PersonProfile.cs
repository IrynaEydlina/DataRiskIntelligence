using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Commands.Persons;

namespace DataRiskIntelligence.Infrastructure.MappingProfiles;

public class PersonProfile : Profile
{
    public PersonProfile()
    {
        CreateMap<Person, PersonDto>();

        CreateMap<CreatePersonCommand, Person>()
            .ForMember(x => x.Quotes, x => x.Ignore());

        CreateMap<UpdatePersonCommand, Person>()
            .ForMember(x => x.Quotes, x => x.Ignore());
    }
}
