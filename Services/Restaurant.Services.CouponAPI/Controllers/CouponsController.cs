using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.CouponAPI.Data.Contexts;
using Restaurant.Services.CouponAPI.Dtos;
using Restaurant.Services.CouponAPI.Mapper;
using Restaurant.Services.CouponAPI.Models;

namespace Restaurant.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CouponsController(AppDbContext _dbContext) : ControllerBase
    {
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetCouponById([FromRoute] int id)
        {
            Coupon? data = await _dbContext.Coupons.FindAsync(id);

            if (data is null)
                return NotFound();

            CouponDto dto = ObjectMapper.Mapper.Map<CouponDto>(data);

            return Ok(ResponseDto<CouponDto>.Sucess(dto, 200));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCouponByCode([FromQuery] string couponCode)
        {
            Coupon? data = await _dbContext.Coupons.FirstOrDefaultAsync(x => x.CouponCode.Equals(couponCode));

            if (data is null)
                return NotFound();

            CouponDto dto = ObjectMapper.Mapper.Map<CouponDto>(data);

            return Ok(ResponseDto<CouponDto>.Sucess(dto, 200));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAllCoupon()
        {
            List<Coupon> datas = await _dbContext.Coupons.ToListAsync();

            List<CouponDto> dtos = ObjectMapper.Mapper.Map<List<CouponDto>>(datas);

            return Ok(ResponseDto<List<CouponDto>>.Sucess(dtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCoupon([FromBody] CouponCreateDto couponCreateDto)
        {
            Coupon data = ObjectMapper.Mapper.Map<Coupon>(couponCreateDto);

            await _dbContext.AddAsync(data);
            await _dbContext.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(201));

        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([FromBody] CouponUpdateDto couponUpdateDto)
        {
            Coupon data = ObjectMapper.Mapper.Map<Coupon>(couponUpdateDto);

            _dbContext.Update(data);
            await _dbContext.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(204));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoupon([FromRoute] int id)
        {
            Coupon? data = await _dbContext.Coupons.FindAsync(id);

            if (data is null)
                return NotFound();

            _dbContext.Remove(data);

            await _dbContext.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(204));
        }
    }
}
