using ApiCrud.Data;
using ApiCrud.Models;
using ApiCrud.Request;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Controllers;

[ApiController]
[Route("ProductController")]
public class ProductController : ControllerBase
{
    private readonly IPostProductRepository _postProductRepository;
    private readonly IGetProductByIdRepository _getProductByIdRepository;
    private readonly IGetProductRepository _getProductRepository;
    private readonly IPatchProductRepository _patchProductRepository;
    private readonly IDeleteProductRepository _deleteProductRepository;

    public ProductController(
        IPostProductRepository postProductRepository,
        IGetProductByIdRepository getProductByIdRepository,
        IGetProductRepository getProductRepository,
        IPatchProductRepository patchProductRepository,
        IDeleteProductRepository deleteProductRepository)
    {
        _postProductRepository = postProductRepository;
        _getProductByIdRepository = getProductByIdRepository;
        _getProductRepository = getProductRepository;
        _patchProductRepository = patchProductRepository;
        _deleteProductRepository = deleteProductRepository;
        
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request)
    {
        try
        {
            await _postProductRepository.CreateProduct(request);
            return NoContent();
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductFromId([FromRoute] int id)
    {
        try
        {
            var response = await _getProductByIdRepository.GetProducById(id);
            return Ok(response);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProduct()
    {
        try
        {
            var response = await _getProductRepository.GetProducAllAsync();
            return Ok(response);
        }
        catch (Exception)
        {

            return BadRequest();
        }
    }

    [HttpPatch("{id}/{price}")]
    public async Task<IActionResult> UpdateProductFromId([FromRoute] int id, [FromRoute] double price)
    {
        try
        {
            var response = await _patchProductRepository.UpdateProductFromId(id, price);
        response!.Price = price;

        return Ok(response);
        }
        catch (Exception)
        {
            
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductFromId([FromRoute] int id)
    {
        try
        {
            await _deleteProductRepository.DeleteProductFromId(id);
            return Ok("Item removido com sucesso");
        }
        catch (ArgumentNullException)
        {
            return BadRequest();
        }

    }
}