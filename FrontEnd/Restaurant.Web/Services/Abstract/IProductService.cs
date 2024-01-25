using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Product;

namespace Restaurant.Web.Services.Abstract
{
    public interface IProductService: IBaseService
    {
        Task<ResponseDto<ProductDto>> GetProductByIdAsync(int id);
        Task<ResponseDto<List<ProductDto>>> GetAllProductsAsync();
        Task<ResponseDto<BlankDto>> CreateProductAsync(CreateProductDto createProductDto);
        Task<ResponseDto<BlankDto>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<ResponseDto<BlankDto>> DeleteProductByIdAsync(int id);
    }
}
