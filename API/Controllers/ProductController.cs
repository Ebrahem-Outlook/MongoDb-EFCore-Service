using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[Controller]")]
[ApiController]
public sealed class ProductController(IProductService productService) : ControllerBase
{

}
