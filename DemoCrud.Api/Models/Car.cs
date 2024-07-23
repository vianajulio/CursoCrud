using DemoCrud.Api.Extensions;
using DemoCrud.Api.Validators;

namespace DemoCrud.Api.Models;

public class Car 
{
	public Guid Id { get; }
	public string Name { get; private set; }
	public decimal Price { get; private set; }

	private Car(string name, decimal price)
	{
		Id = Guid.NewGuid();
		Name = name;
		Price = price;
	}
	
	public void UpdateData(UpdateCarRequest command,
		CarValidator validator)
	{
		validator.ValidateCommand(command);

		Name = command.Name;
		Price = command.Price;
	}

	public static Car Create(CreateCarRequest command,
		CarValidator validator)
	{
		validator.ValidateCommand(command);

		return new Car(command.Name, command.Price);
	}
}
