using Microsoft.AspNetCore.Mvc;

namespace DemoCrud.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class CarsController : ControllerBase
{
	private readonly ICarService _carService;

	public CarsController(ICarService carService)
	{
		_carService = carService;
	}

	[HttpGet]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Car>))]
	public async Task<IActionResult> Get() => Ok(await _carService.GetAllAsync());

	[HttpGet("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Get(Guid id)
	{
		var car = await _carService.GetByIdAsync(id);
		if (car is null)
			return NotFound();
		
		return Ok(car);
	}

	[HttpPost]
	[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Car))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Post([FromBody] CreateCarRequest request)
	{
		var car = await _carService.AddAsync(request);

		return CreatedAtAction("Get", new { car.Id }, car);
	}

	[HttpPut("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Put(Guid id, [FromBody] UpdateCarRequest request)
	{
		var car = await _carService.UpdateAsync(id, request);

		return car is null ? NotFound() : Ok(car);
	}

	[HttpDelete("{id:guid}")]
	[ProducesResponseType(StatusCodes.Status204NoContent)]
	[ProducesResponseType(StatusCodes.Status404NotFound)]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _carService.DeleteAsync(id);

		return NoContent();
	}
}
