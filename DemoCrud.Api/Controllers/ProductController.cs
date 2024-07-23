using Microsoft.AspNetCore.Mvc;

namespace DemoCrud.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
[Consumes("application/json")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        var result = await _productService.GetAllProducts();
        return Ok(result);
    }

}
