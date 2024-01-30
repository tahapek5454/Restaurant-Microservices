using Restaurant.Integration.Domain.Dtos;

namespace Restaurant.Web.Services.Abstract
{
    public interface IBaseService
    {
        Task<ResponseDto<TResponse>> SendAsync<TRequest, TResponse>(RequestDto<TRequest> requestDto, bool isAuthorize=true) 
            where TResponse: class;
    }
}
