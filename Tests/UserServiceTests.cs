using System.Threading.Tasks;
using Application.Dtos;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Auth;
using Moq;
using Xunit;

namespace Tests
{
    public class UserServiceTests
    {
        private readonly IJwtService _jwtService = Mock.Of<IJwtService>();

        [Fact]
        public async Task RegisterAsync_Should_Register_New_User()
        {
            // Arrange
            var service = new UserService(_jwtService);
            var registerUser = new RegisterDto
            {
                Username = "maher123",
                Password = "password999"
            };
            // Act
            var result = await service.RegisterAsync(registerUser);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task LoginAsync_Should_Return_Token_If_User_Is_Valid()
        {
            // Arrange
            var mockJwtService = new Mock<IJwtService>();
            mockJwtService.Setup(j => j.GenerateToken(It.IsAny<UserDto>()))
                          .Returns("fake-jwt-token");

            var service = new UserService(mockJwtService.Object);
            var registerUser = new RegisterDto
            {
                Username = "maher",
                Password = "password123"
            };
            await service.RegisterAsync(registerUser);
            var loginUser = new LoginDto
            {
                Username = "maher",
                Password = "password123"
            };
            // Act
            var token = await service.LoginAsync(loginUser);

            // Assert
            Assert.NotNull(token);
            Assert.Equal("fake-jwt-token", token);
        }
    }
}
