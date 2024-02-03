using Restaurant.Integration.Domain.Dtos;

namespace Restaurant.Services.ShoppingCartAPI.Services.Abstract
{
    public interface IBaseService
    {
        Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto, bool isAuthorize = true)
            where TResponse : class;
    }
}
