//using System.Text.Json;

//namespace DemoCrud.Api.Repositories;

//public class CarFileRepository : ICarRepository
//{
//	public async Task<Car?> GetByIdAsync(Guid id)
//	{
//		var file = Directory.GetFiles("e:\\", "*.json")
//			.ToList()
//			.Find(x => x.Contains(id.ToString()));
//		if (file is null)
//			return default;

//		var content = await File.ReadAllTextAsync(file);

//		var car = JsonSerializer.Deserialize<Car?>(content);

//		return car;
//	}

//	public Task<IReadOnlyCollection<Car>> GetAllAsync()
//	{
//		throw new NotImplementedException();
//	}

//	public Task AddAsync(Car car)
//	{
//		using var sw = new StreamWriter($"e:\\{car.Id}.json");

//		sw.WriteLine(JsonSerializer.Serialize(car));

//		return Task.CompletedTask;
//	}

//	public Task UpdateAsync(Car car)
//	{
//		throw new NotImplementedException();
//	}

//	public Task DeleteAsync(Car car)
//	{
//		throw new NotImplementedException();
//	}
//}
