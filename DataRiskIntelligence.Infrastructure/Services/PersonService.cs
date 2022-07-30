using DataRiskIntelligence.Domain.Entities;
using DataRiskIntelligence.Persistance;
using Microsoft.EntityFrameworkCore;

namespace DataRiskIntelligence.Infrastructure.Services;

public class PersonService : ICrudService<Person>
{
    private readonly DataRiskDbContext _context;

    public PersonService(DataRiskDbContext context)
    {
        _context = context;
    }
    public Task<List<Person>> GetAllAsync(CancellationToken cancellationToken) => _context.People.Include(x => x.Quotes).ToListAsync(cancellationToken);
    public Task<Person> GetByIdAsync(int id, CancellationToken cancellationToken) => _context.People.Include(x => x.Quotes).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    public async Task<int> CreatePersonAsync(string firstName, string lastName, CancellationToken cancellationToken)
    {
        var person = new Person()
        {
            FirstName = firstName,
            LastName = lastName
        };
        _context.People.Add(person);
        await _context.SaveChangesAsync(cancellationToken);

        return person.Id;
    }

    public async Task<int> CreateAsync(Person model, CancellationToken cancellationToken)
    {
        _context.People.Add(model);
        await _context.SaveChangesAsync(cancellationToken);

        return model.Id;
    }

    public async Task<bool> UpdateAsync(Person model, CancellationToken cancellationToken)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == model.Id, cancellationToken);
        if (person != null)
        {
            person.FirstName = model.FirstName;
            person.LastName = model.LastName;
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
        return false;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var person = await _context.People.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (person != null)
        {
            _context.People.Remove(person);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }

        return false;
    }
}
