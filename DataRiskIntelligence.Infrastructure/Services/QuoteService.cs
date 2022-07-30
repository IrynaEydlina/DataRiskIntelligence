using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DataRiskIntelligence.Infrastructure.Services;

public class QuoteService : ICrudService<Quote>
{
    private readonly DataRiskDbContext _context;

    public QuoteService(DataRiskDbContext context)
    {
        _context = context;
    }

    public Task<List<Quote>> GetAllAsync(CancellationToken cancellationToken) => _context.Quotes.Include(x => x.Person).ToListAsync(cancellationToken);
    public Task<Quote> GetByIdAsync(int id, CancellationToken cancellationToken) => _context.Quotes.Include(x => x.Person).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<int> CreateAsync(Quote model, CancellationToken cancellationToken)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == model.Person.Id, cancellationToken);
        if (person == null)
        {
            return -1;
        }
        model.Person = person;
        _context.Quotes.Add(model);
        await _context.SaveChangesAsync(cancellationToken);

        return model.Id;
    }

    public async Task<bool> UpdateAsync(Quote model, CancellationToken cancellationToken)
    {
        var quote = await _context.Quotes.FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == model.Person.Id, cancellationToken);
        if (quote != null && person != null)
        {
            quote.Text = model.Text;
            quote.Person = model.Person;
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var quote = await _context.Quotes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (quote != null)
        {
            _context.Quotes.Remove(quote);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
