using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using UserService;
using UserService.Application.Command;
using Xunit;

namespace UsersService.Tests.Integration
{
    public class UserControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UserControllerTests(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("User")]
        public async Task Can_Create_User(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var command = new CreateUserCommand()
            {
                FirstName = "Damon",
                LastName = "Murphy",
                DateOfBirth = DateTimeOffset.Now.AddDays(-1),
                Address = "11 Hospital Road"
            };

            var serializedCommand = JsonConvert.SerializeObject(command);

            var content = new StringContent(
                serializedCommand,
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            response.EnsureSuccessStatusCode();
            var user = await response.Content.ReadAsAsync<UserDto>();
            Assert.NotNull(user);
        }

        [Theory]
        [InlineData("User")]
        public async Task Create_User_Invalid_Name(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            var command = new CreateUserCommand()
            {
                FirstName = "123",
                LastName = "Murphy",
                DateOfBirth = DateTimeOffset.Now.AddDays(-1),
                Address = "11 Hospital Road"
            };

            var serializedCommand = JsonConvert.SerializeObject(command);

            var content = new StringContent(
                serializedCommand,
                Encoding.UTF8,
                "application/json");

            // Act
            var response = await client.PostAsync(url, content);

            // Assert
            response.Equals(HttpStatusCode.BadRequest);
            var responseContent = await response.Content.ReadAsStringAsync();
            Assert.True(responseContent.Contains("errorMessage"));
        }

    }
}