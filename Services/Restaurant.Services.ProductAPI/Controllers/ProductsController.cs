using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ProductAPI.Data.Contexts;
using Restaurant.Services.ProductAPI.Mapper;
using Restaurant.Services.ProductAPI.Models;
using Restaurant.Services.ProductAPI.Models.Dtos;

namespace Restaurant.Services.ProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(AppDbContext _appDbContext) : ControllerBase
    {

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetProductById([FromRoute]int id)
        {
            var entity = await _appDbContext.Products.AsNoTracking().FirstAsync(x => x.Id == id);

            var dto = ObjectMapper.Mapper.Map<ProductDto>(entity);

            return Ok(ResponseDto<ProductDto>.Sucess(dto, 200));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetAllProducts()
        {
            var entities = await _appDbContext.Products.AsNoTracking().ToListAsync();

            var dtos = ObjectMapper.Mapper.Map<List<ProductDto>>(entities);

            return Ok(ResponseDto<List<ProductDto>>.Sucess(dtos, 200));
        }

        [HttpPost, Authorize(Roles ="admin")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var newEntity = ObjectMapper.Mapper.Map<Product>(createProductDto);

            await _appDbContext.AddAsync(newEntity);

            await _appDbContext.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(201));
        }

        [HttpPut, Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var updatedEntity = ObjectMapper.Mapper.Map<Product>(updateProductDto);

            _appDbContext.Update(updatedEntity);

            await _appDbContext.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(204));
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteProductById([FromRoute] int id)
        {
            var entity = await _appDbContext.Products.AsNoTracking().FirstAsync(x => x.Id == id);

            if (entity == null)
                return BadRequest(ResponseDto<BlankDto>.Fail("Product Not Found",true, 500));

            _appDbContext.Remove(entity);

            await _appDbContext.SaveChangesAsync();

            return Ok(ResponseDto<ProductDto>.Sucess(204));
        }

    }
}
