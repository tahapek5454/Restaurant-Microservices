using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ShoppingCartAPI.Data.Contexts;
using Restaurant.Services.ShoppingCartAPI.Mapper;
using Restaurant.Services.ShoppingCartAPI.Models;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;

namespace Restaurant.Services.ShoppingCartAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController(AppDbContext _appDbContext) : ControllerBase
    {
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
    }
}
