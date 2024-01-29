using Newtonsoft.Json;
using Restaurant.Integration.Domain.Consts;
using Restaurant.Integration.Domain.Dtos;
using Restaurant.Services.ShoppingCartAPI.Models.Dtos;
using Restaurant.Services.ShoppingCartAPI.Services.Abstract;


namespace Restaurant.Services.ShoppingCartAPI.Services.Concrete
{
    public class ProductService(IHttpClientFactory _httpClientFactory) : IProductService
    {
        public async Task<ProductDto> GetAllProductById(int id)
        {
            var client = _httpClientFactory.CreateClient("Product");
            var httpResponse = await client.GetAsync($"{ConstData.ProductAPIBase}/Products/{id}");


            var response = JsonConvert.DeserializeObject<ResponseDto<ProductDto>>(await httpResponse.Content.ReadAsStringAsync());

            return response?.Data;
        }

        public async Task<IEnumerable<ProductDto>> GetAllProducts()
        {
            var client = _httpClientFactory.CreateClient("Product");
            var httpResponse = await client.GetAsync($"{ConstData.ProductAPIBase}/Products");
            var response = JsonConvert.DeserializeObject<ResponseDto<List<ProductDto>>>(await httpResponse.Content.ReadAsStringAsync());

            return response?.Data ?? Enumerable.Empty<ProductDto>();    
        }

    }
}
