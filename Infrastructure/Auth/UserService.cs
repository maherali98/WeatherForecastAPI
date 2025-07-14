using System.Security.Cryptography;
using System.Text;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;

namespace Infrastructure.Auth;

public class UserService : IUserService
{
    private static readonly List<User> _users = new();
    private readonly IJwtService _jwtService;

    public UserService(IJwtService jwtService)
    {
        _jwtService = jwtService;
    }

    public Task<bool> RegisterAsync(RegisterDto input)
    {
        if (_users.Any(u => u.Username == input.Username))
            return Task.FromResult(false);

        var user = new User
        {
            Username = input.Username,
            Password = HashPassword(input.Password)
        };

        _users.Add(user);
        return Task.FromResult(true);
    }

    public Task<string?> LoginAsync(LoginDto input)
    {
        var user = _users.SingleOrDefault(u => u.Username == input.Username);
        if (user == null || user.Password != HashPassword(input.Password))
            return Task.FromResult<string?>(null);
        var userDto = new UserDto
        {
            Username = input.Username,
            PasswordHash = HashPassword(input.Password)
        };
        var token = _jwtService.GenerateToken(userDto);
        return Task.FromResult<string?>(token);
    }

    private string HashPassword(string password)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}
