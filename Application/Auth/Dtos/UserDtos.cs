namespace Application.Auth.Dtos
{
    public class RegisterUserDto
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }

    public class LoginUserDto
    {
        public string Name {get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserDtoResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = new();
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public UserDtoResponse? User { get; set; }
    }
}
