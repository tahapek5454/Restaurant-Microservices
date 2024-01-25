using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Models.Dtos.Product;
using Restaurant.Web.Services.Abstract;

namespace Restaurant.Web.Services.Concrete
{
    public class ProductService : BaseService, IProductService
    {
        public ProductService(IHttpClientFactory _httpClientFactory) : base(_httpClientFactory)
        {
        }

        public async Task<ResponseDto<BlankDto>> CreateProductAsync(CreateProductDto createProductDto)
            => await SendAsync<CreateProductDto, BlankDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.POST,
                Data = createProductDto,
                Url = $"{ConstData.ProductAPIBase}/Products",
                AccessToken = null
            });

        public async Task<ResponseDto<BlankDto>> DeleteProductByIdAsync(int id)
            => await SendAsync<BlankDto, BlankDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.DELETE,
                Data = null,
                Url = $"{ConstData.ProductAPIBase}/Products/{id}",
                AccessToken = null
            });

        public async Task<ResponseDto<List<ProductDto>>> GetAllProductsAsync()
            => await SendAsync<BlankDto, List<ProductDto>>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Data = null,
                Url = $"{ConstData.ProductAPIBase}/Products",
                AccessToken = null
            });

        public async Task<ResponseDto<ProductDto>> GetProductByIdAsync(int id)
            => await SendAsync<BlankDto, ProductDto>(new()
            {
                ActionType = Integration.Domain.Enums.ActionType.GET,
                Data = null,
                Url = $"{ConstData.ProductAPIBase}/Products/{id}",
                AccessToken = null
            });

        public async Task<ResponseDto<BlankDto>> UpdateProductAsync(UpdateProductDto updateProductDto)
             => await SendAsync<UpdateProductDto, BlankDto>(new()
             {
                 ActionType = Integration.Domain.Enums.ActionType.PUT,
                 Data = updateProductDto,
                 Url = $"{ConstData.ProductAPIBase}/Products",
                 AccessToken = null
             });
    }
}
