using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Queries.Persons
{
    public class GetPeopleQuery : IRequest<List<PersonDto>>
    {
        public class GetPeopleHandler : IRequestHandler<GetPeopleQuery, List<PersonDto>>
        {
            private readonly ICrudService<Person> _service;
            private readonly IMapper _mapper;

            public GetPeopleHandler(ICrudService<Person> service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<List<PersonDto>> Handle(GetPeopleQuery request, CancellationToken cancellationToken)
            {
                var people = await _service.GetAllAsync(cancellationToken);

                return _mapper.Map<List<PersonDto>>(people);
            }
        }
    }
}
