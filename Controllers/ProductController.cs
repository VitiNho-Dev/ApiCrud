using ApiCrud.Data;
using ApiCrud.Models;
using ApiCrud.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers;

[ApiController]
[Route("ProductController")]
public class ProductController : ControllerBase
{
    private readonly MyDbContext _myDbContext;

    public ProductController(MyDbContext dbContext)
    {
        _myDbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        ProductModel productModel =
            new()
            {
                Name = request.Name,
                Price = request.Price,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

        await _myDbContext.AddAsync(productModel);
        await _myDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductFromId([FromRoute] int id)
    {
        var response = await _myDbContext.Product.FirstAsync(key => key.Id == id);

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        var response = await _myDbContext.Product.ToListAsync();

        return Ok(response);
    }

    [HttpPatch("{id}/{price}")]
    public async Task<IActionResult> UpdateProductFromId([FromRoute] int id, [FromRoute] double price)
    {
        var response = await _myDbContext.Product.FindAsync(id);
        response.Price = price;

        await _myDbContext.SaveChangesAsync();

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductFromId([FromRoute] int id)
    {
        try
        {
            var response = await _myDbContext.Product.FirstAsync(key => key.Id == id);
            _myDbContext.Product.Remove(response);
            await _myDbContext.SaveChangesAsync();
            return Ok(response);
        }
        catch (ArgumentNullException)
        {
            return BadRequest();
        }

    }
}