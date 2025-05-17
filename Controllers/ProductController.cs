using eaybe.DTOs;
using ebaybe.Services;
using Microsoft.AspNetCore.Mvc;

namespace eaybe.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _service.GetAll();
        if (products is null || products.Count == 0)
            return new ResponseEntity(404, null, "Không tìm thấy sản phẩm nào");
        return new ResponseEntity(200, products, "Lấy danh sách sản phẩm thành công");
    }
        

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var product = await _service.GetById(id);
        if (product is null)
            return new ResponseEntity(404, null, "Không tìm thấy sản phẩm");
        return new ResponseEntity(200, product, "Lấy sản phẩm thành công");
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ProductDto dto)
    {
        var created = await _service.Create(dto);
        return new ResponseEntity(201, created, "Tạo sản phẩm thành công");
    }
}
