using API.Contracts;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ProductController(IProductService productService) : ControllerBase
{
    public async Task<IActionResult> Create(CreateProductRequest request)
    {
        return await productService.
    }
}
