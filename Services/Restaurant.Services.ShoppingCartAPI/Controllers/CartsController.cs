using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ShoppingCartAPI.Data.Contexts;
using Restaurant.Services.ShoppingCartAPI.Mapper;
using Restaurant.Services.ShoppingCartAPI.Models;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;
using Restaurant.Services.ShoppingCartAPI.Services.Abstract;

namespace Restaurant.Services.ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(AppDbContext _appDbContext, IProductService _productService) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCart([FromRoute] int id)
        {
            try
            {
                var cartHeader = await _appDbContext.CartHeaders.FirstOrDefaultAsync(x => x.UserId == id);

                if (cartHeader is null)
                    throw new Exception("Cart Header Not Found");

                var cartDetails = await _appDbContext.CartDetails.Where(x => x.CartHeaderId == cartHeader.Id).ToListAsync();

                IEnumerable<ProductDto> productDtos = await _productService.GetAllProducts();

                foreach (var cartDetail in cartDetails)
                {
                    cartDetail.Product = productDtos?.FirstOrDefault(x => x.Id.Equals(cartDetail.ProductId));
                    cartHeader.CartTotal += (cartDetail?.Product?.Price ?? 0) * (cartDetail?.Count ?? 0);
                }

                CartDto cartDto = new()
                {
                    CartDetails = ObjectMapper.Mapper.Map<List<CartDetailDto>>(cartDetails),
                    CartHeader = ObjectMapper.Mapper.Map<CartHeaderDto>(cartHeader)
                };

                return Ok(ResponseDto<CartDto>.Sucess(cartDto, 200));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Upsert([FromBody]CartDto cartDto)
        {
            try
            {
                var cartHeader = await _appDbContext.CartHeaders.FirstOrDefaultAsync(x => x.Id.Equals(cartDto.CartHeader.Id));
                
                if(cartHeader is null)
                {
                    cartHeader = ObjectMapper.Mapper.Map<CartHeader>(cartDto.CartHeader);
                    await _appDbContext.AddAsync(cartHeader);
                    await _appDbContext.SaveChangesAsync();

                    cartDto.CartHeader.Id = cartHeader.Id;  

                    foreach (var cartDetail in cartDto.CartDetails)
                    {
                        cartDetail.CartHeaderId = cartHeader.Id;
                    }

                }

                List<CartDetail> willUpdateCartDetails = new();
                foreach (var cartDetail in cartDto.CartDetails)
                {
                    var cartDetailFromDb = await _appDbContext.CartDetails
                        .FirstOrDefaultAsync(x => x.CartHeaderId.Equals(cartDetail.CartHeaderId) && x.ProductId.Equals(cartDetail.ProductId));

                    if(cartDetailFromDb is null)
                    {
                        cartDetailFromDb = ObjectMapper.Mapper.Map<CartDetail>(cartDetail);
                        await _appDbContext.AddAsync(cartDetailFromDb);
                        await _appDbContext.SaveChangesAsync();

                        cartDetail.Id = cartDetailFromDb.Id;

                        continue;
                    }

                    cartDetailFromDb.Count += cartDetail.Count;

                    cartDetail.Count = cartDetailFromDb.Count;

                    willUpdateCartDetails.Add(cartDetailFromDb);
                }

                if (willUpdateCartDetails.Any())
                {
                    _appDbContext.UpdateRange(willUpdateCartDetails);
                    await _appDbContext.SaveChangesAsync();
                }

                return Ok(ResponseDto<CartDto>.Sucess(cartDto, 200));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);  
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCart([FromBody] int cartDetailId)
        {
            try
            {
                CartDetail? cartDetail = await _appDbContext.CartDetails.FirstOrDefaultAsync(x => x.Id.Equals(cartDetailId));

                if (cartDetail is null)
                {
                    throw new Exception("CartDetails not found");
                }

                int totalCartDetailsCountForHeader = await _appDbContext.CartDetails.Where(x => x.CartHeaderId.Equals(cartDetail.CartHeaderId)).CountAsync();
                _appDbContext.Remove(cartDetail);

                if (totalCartDetailsCountForHeader == 1)
                    _appDbContext.Remove(_appDbContext.CartHeaders.First(x => x.Id.Equals(cartDetail.CartHeaderId)));

                await _appDbContext.SaveChangesAsync();

                return Ok(ResponseDto<BlankDto>.Sucess(201));

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
