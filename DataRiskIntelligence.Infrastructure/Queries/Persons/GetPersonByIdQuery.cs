using AutoMapper;
using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Dtos;
using DataRiskIntelligence.Infrastructure.Services;
using MediatR;

namespace DataRiskIntelligence.Infrastructure.Queries.Persons
{
    public class GetPersonByIdQuery : IRequest<PersonDto>
    {
        private int Id { get; }

        public GetPersonByIdQuery(int id) => Id = id;

        public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDto>
        {
            private readonly ICrudService<Person> _service;
            private readonly IMapper _mapper;

            public GetPersonByIdHandler(ICrudService<Person> service, IMapper mapper)
            {
                _service = service;
                _mapper = mapper;
            }

            public async Task<PersonDto> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
            {

                var person = await _service.GetByIdAsync(request.Id, cancellationToken);
                if (person == null)
                {
                    return null;
                }

                return _mapper.Map<PersonDto>(person);
            }
        }
    }
}
