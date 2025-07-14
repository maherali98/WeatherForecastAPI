using Application.Dtos;
using Domain.Entities;

namespace Application.Interfaces;

public interface IJwtService
{
    string GenerateToken(UserDto user);
}