namespace DemoCrud.Api.Requests;

public record CreateCarRequest(string Name, decimal Price) : BaseCarRequest(Name, Price);

//public record CreateCarRequest
//{
//	public string Name { get; set; } = default!;
//	public decimal Price { get; set; }
//}

