namespace DemoCrud.Api.Requests;

public record UpdateCarRequest(string Name, decimal Price) : BaseCarRequest(Name, Price);


//public class UpdateCarRequest
//{
//	public string Name { get; }
//	public string Name { get; }
//	public decimal Price { get; }

//	public UpdateCarRequest(string name, decimal price)
//	{
//		Name = name;
//		Price = price;
//	}
//}
