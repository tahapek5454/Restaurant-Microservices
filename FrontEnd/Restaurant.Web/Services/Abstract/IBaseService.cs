using Restaurant.Integration.Domain.Dtos;

namespace Restaurant.Web.Services.Abstract
{
    public interface IBaseService<TRequest, TResponse> 
        where TRequest : class
        where TResponse : class
    {
        Task<ResponseDto<TResponse>> SendAsync(RequestDto<TRequest> requestDto);
    }
}
