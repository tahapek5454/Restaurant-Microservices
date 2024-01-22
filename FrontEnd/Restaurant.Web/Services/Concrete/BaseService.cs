using Restaurant.Integration.Domain.Dtos;
using Restaurant.Web.Services.Abstract;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Restaurant.Web.Services.Concrete
{
    public class BaseService(IHttpClientFactory _httpClientFactory) : IBaseService
    {
        public async Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto)
            where TRequest : class
			where TResponse : class
        {
			try
			{
				HttpClient client = _httpClientFactory.CreateClient("RestaurantAPI");
				HttpRequestMessage message = new();

				// token operations

				message.RequestUri = new Uri(requestDto.Url);

				if(requestDto.Data is not null)
				{
					message.Content =
						new StringContent
						(JsonSerializer.Serialize(requestDto.Data), Encoding.UTF8, MediaTypeNames.Application.Json);
				}

				HttpResponseMessage? apiResponse = null;

				message.Method = requestDto.ActionType switch
				{
					Integration.Domain.Enums.ActionType.POST => HttpMethod.Post,
					Integration.Domain.Enums.ActionType.PUT => HttpMethod.Put,
					Integration.Domain.Enums.ActionType.DELETE => HttpMethod.Delete,
					_ => HttpMethod.Get
				};

				apiResponse = await client.SendAsync(message);

                ResponseDto<TResponse>? result = apiResponse.StatusCode switch
				{
					System.Net.HttpStatusCode.NotFound => ResponseDto<TResponse>.Fail("Not Found", true, 404),
					System.Net.HttpStatusCode.Forbidden => ResponseDto<TResponse>.Fail("Forbidden", true, 403),
					System.Net.HttpStatusCode.Unauthorized => ResponseDto<TResponse>.Fail("Unauthorized", true, 401),
					System.Net.HttpStatusCode.InternalServerError => ResponseDto<TResponse>.Fail("Internal Server Error", true, 500),
					_ => null
                };

				if(result is null)
                    result = JsonSerializer.Deserialize<ResponseDto<TResponse>>(await apiResponse.Content.ReadAsStringAsync());


				return result ?? ResponseDto<TResponse>.Fail("Deserialize failed", false, 500);
            }
			catch (Exception ex)
			{
				return ResponseDto<TResponse>.Fail(ex.Message, false, 500);
            }
        }

        
    }
}
