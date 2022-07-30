using DataRiskIntelligence.Infrastructure.Commands.Quotes;
using DataRiskIntelligence.Infrastructure.Queries.Quotes;
using DataRistIntelligence.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DataRistIntelligence.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    private readonly IMediator _mediator;

    public QuotesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var query = new GetQuoteQuery();
        var people = await _mediator.Send(query);

        return Ok(people);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetQuoteyIdQuery(id);
        var person = await _mediator.Send(query);
        if(person == null)
        {
            return NotFound();
        }

        return Ok(person);
    }

    [HttpPost]
    public async Task<IActionResult> Create(QuoteModel model)
    {
        var command = new CreateQuoteCommand(model.Text, model.PersonId);
        var quoteId = await _mediator.Send(command);

        return Created($"{Request.Host}{Request.Path}/{quoteId}", quoteId);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteQuoteCommand(id);
        var isDeleted = await _mediator.Send(command);
        if (!isDeleted)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, QuoteModel model)
    {
        var command = new UpdateQuoteCommand(id, model.Text, model.PersonId);
        var isUpdated = await _mediator.Send(command);
        if (!isUpdated)
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("GetDayQuote")]
    public async Task<IActionResult> GetDayQuote()
    {
        var query = new GeDayQuoteQuery();
        var quote = await _mediator.Send(query);
        if (quote == null)
        {
            return NotFound();
        }

        return Ok(quote);
    }
}