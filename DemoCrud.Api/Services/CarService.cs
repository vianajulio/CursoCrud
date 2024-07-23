using DemoCrud.Api.Repositories;
using DemoCrud.Api.Validators;

namespace DemoCrud.Api.Services;

public class CarService(ICarRepository carRepository,
	CarValidator validator) : ICarService
{
	public async Task<Car> AddAsync(CreateCarRequest request)
	{
		var car = Car.Create(request, validator);

		var exists = await carRepository.ExistsAsync(car);
		if (exists)
			throw new DomainException("Já existe um veículo com esse nome.");

		await carRepository.AddAsync(car);

		//enviar um email
		//colocar uma mensagem na fila no broker (rabbitmq, kafka, sqs)

		return car;
	}

	public async Task<Car?> UpdateAsync(Guid id, UpdateCarRequest request)
	{
		var car = await carRepository.GetByIdAsync(id);
		if (car is null)
			return default;
		
		car.UpdateData(request, validator);

		var exists = await carRepository.ExistsAsync(car);
		if (exists)
			throw new DomainException("Já existe um veículo com esse nome.");

		await carRepository.UpdateAsync(car);

		return car;
	}

	public async Task DeleteAsync(Guid id)
	{
		var car = await carRepository.GetByIdAsync(id);//?? throw new NotFoundException();
		if (car is null)
			throw new NotFoundException();

		await carRepository.DeleteAsync(car);
	}

	public Task<IReadOnlyCollection<Car>> GetAllAsync() => carRepository.GetAllAsync();

	public Task<Car?> GetByIdAsync(Guid id) => carRepository.GetByIdAsync(id);
}
