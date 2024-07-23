namespace DemoCrud.Api.Repositories;

public interface ICarRepository
{
	Task<Car?> GetByIdAsync(Guid id);

	Task<bool> ExistsAsync(Car car);

	Task<IReadOnlyCollection<Car>> GetAllAsync();

	Task AddAsync(Car car);

	Task UpdateAsync(Car car);

	Task DeleteAsync(Car car);
}
