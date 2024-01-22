using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.CouponAPI.Data.Contexts;
using Restaurant.Services.CouponAPI.Dtos;
using Restaurant.Services.CouponAPI.Mapper;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController(AppDbContext _dbContext) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var datas = await _dbContext.Coupons.ToListAsync();

            var dtos = ObjectMapper.Mapper.Map<List<CouponDto>>(datas);

            var response = ResponseDto<List<CouponDto>>.Sucess(dtos, 200);

            return Ok(response);
        }
    }
}
