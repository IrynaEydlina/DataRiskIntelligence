namespace DataRiskIntelligence.Infrastructure.Services;

public interface ICrudService<T>
{
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<int> CreateAsync(T model, CancellationToken cancellationToken);
    Task<bool> UpdateAsync(T model, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken);
}
