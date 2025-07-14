using System.Net.Http.Json;
using Application.Dtos;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public IntegrationTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Register_Login_And_Get_Weather()
        {
            var client = _factory.CreateClient();
            var registerUser = new RegisterDto
            {
                Username = "maher",
                Password = "123456"
            };
            // Register
            var register = await client.PostAsJsonAsync("/api/auth/register", registerUser);
            Assert.True(register.IsSuccessStatusCode);

            // Login
            var loginUser = new LoginDto
            {
                Username = "maher",
                Password = "123456"
            }; ;           

            var loginResponse = await client.PostAsJsonAsync("/api/auth/login", loginUser);
            Assert.True(loginResponse.IsSuccessStatusCode);

            var loginContent = await loginResponse.Content.ReadFromJsonAsync<LoginResultDto>();
            var token = loginContent?.Token;
            Assert.NotNull(token);

            // Authenticated weather request
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var weatherResponse = await client.GetAsync("/api/weather?city=Cairo");
            Assert.True(weatherResponse.IsSuccessStatusCode);
        }
    }
}
