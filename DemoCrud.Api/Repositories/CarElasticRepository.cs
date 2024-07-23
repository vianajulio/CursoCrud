using Nest;

namespace DemoCrud.Api.Repositories;

public class CarElasticRepository : ICarRepository
{
	private readonly IElasticClient elasticClient;

	public CarElasticRepository(IElasticClient elasticClient)
	{
		this.elasticClient = elasticClient;
	}

	public Task<Car?> GetByIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<bool> ExistsAsync(Car car)
	{
		throw new NotImplementedException();
	}

	public Task<IReadOnlyCollection<Car>> GetAllAsync()
	{
		throw new NotImplementedException();
	}

	public Task AddAsync(Car car)
	{
		throw new NotImplementedException();
	}

	public Task UpdateAsync(Car car)
	{
		throw new NotImplementedException();
	}

	public Task DeleteAsync(Car car)
	{
		throw new NotImplementedException();
	}
}
