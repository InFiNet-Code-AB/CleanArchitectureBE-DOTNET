using Application.Auth;
using Application.Auth.Dtos;
using Domain.Models.Common;
using Infrastructure.Configuration;
using Infrastructure.Database;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly JwtSettings _jwtSettings;

        public AuthRepository(AppDbContext context, IOptions<JwtSettings> jwtOptions)
        {
            _context = context;
            _jwtSettings = jwtOptions.Value;
        }

        public Task<OperationResult<AuthResponseDto>> LoginAsync(LoginUserDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResult<AuthResponseDto>> RegisterAsync(RegisterUserDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
