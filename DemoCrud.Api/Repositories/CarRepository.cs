using DemoCrud.Api.Contexts;
using Microsoft.EntityFrameworkCore;

namespace DemoCrud.Api.Repositories;

public class CarRepository : ICarRepository
{
	private readonly DataContext _context;

	public CarRepository(DataContext context)
	{
		_context = context;
	}

	public async Task AddAsync(Car car)
	{
		await _context.Cars.AddAsync(car);
		await _context.SaveChangesAsync();
	}

	public async Task DeleteAsync(Car car)
	{
		_context.Cars.Remove(car);

		await _context.SaveChangesAsync();
	}

	public Task<bool> ExistsAsync(Car car) => _context.Cars.AnyAsync(x => x.Name == car.Name && x.Id != car.Id);

	public async Task<IReadOnlyCollection<Car>> GetAllAsync()
	{
		return await _context.Cars
			.AsNoTracking()
			.OrderBy(x => x.Name)
			.ToListAsync();
	}

	public Task<Car?> GetByIdAsync(Guid id) => _context.Cars.FirstOrDefaultAsync(x => x.Id == id);

	public async Task UpdateAsync(Car car)
	{
		_context.Update(car);
		await _context.SaveChangesAsync();
	}
}
