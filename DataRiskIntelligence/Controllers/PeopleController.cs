using DataRiskIntelligence.Infrastructure.Commands.Persons;
using DataRiskIntelligence.Infrastructure.Queries.Persons;
using DataRistIntelligence.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataRistIntelligence.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IMediator _mediator;

    public PeopleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetPeopleQuery();
        var people = await _mediator.Send(query);

        return Ok(people);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetPersonByIdQuery(id);
        var person = await _mediator.Send(query);
        if (person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(PersonModel model)
    {
        var command = new CreatePersonCommand(model.FirstName, model.LastName);
        var personId = await _mediator.Send(command);

        return Created($"{Request.Host}{Request.Path}/{personId}", personId);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeletePersonCommand(id);
        var isDeleted = await _mediator.Send(command);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPatch("{id:int}")]
    public async Task<IActionResult> Update(int id, PersonModel model)
    {
        var command = new UpdatePersonCommand(id, model.FirstName, model.LastName);
        var isUpdated = await _mediator.Send(command);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }
}