using EFUpskilling.Entities;
using EnigmatShopAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EnigmatShopAPI.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateNewProduct([FromBody] Product payload)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
         
        var product = await _productService.Create(payload);
        return Created("/api/products", product);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var products = await _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(string id)
    {
        var product = await _productService.GetById(id);
        return Ok(product);
    }

}