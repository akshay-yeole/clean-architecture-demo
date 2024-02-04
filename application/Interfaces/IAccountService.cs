using application.Dtos;
using application.Wrappers;

namespace application.Interfaces
{
    public interface IAccountService
    {
        Task<ApiResponse<Guid>> RegisterUser(RegisterRequest registerRequest);
    }
}
