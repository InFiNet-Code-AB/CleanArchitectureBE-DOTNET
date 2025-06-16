using Application.Auth.Dtos;
using Domain.Models.Common;

namespace Application.Auth
{
    public interface IAuthRepository
    {
        Task<OperationResult<AuthResponseDto>> RegisterAsync(RegisterUserDto dto);
        Task<OperationResult<AuthResponseDto>> LoginAsync(LoginUserDto dto);
    }
}
