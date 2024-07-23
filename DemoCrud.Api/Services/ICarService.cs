using DemoCrud.Api.Requests;

namespace DemoCrud.Api.Services;

public interface ICarService
{
	Task<Car> AddAsync(CreateCarRequest request);

	Task<Car?> UpdateAsync(Guid id, UpdateCarRequest request);

	Task DeleteAsync(Guid id);
	
	Task<IReadOnlyCollection<Car>> GetAllAsync();

	Task<Car?> GetByIdAsync(Guid id);
}
