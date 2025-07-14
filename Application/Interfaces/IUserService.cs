using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IUserService
{
    Task<bool> RegisterAsync(RegisterDto input);
    Task<string?> LoginAsync(LoginDto input);
}