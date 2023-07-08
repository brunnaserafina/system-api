using MeuProjetoMVC.Controllers;
using MeuProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MeuProjetoMVC.Tests
{
    public class AuthControllerTests
    {
        [Fact]
        public void Login_ValidCredentials_ReturnsToken()
        {
            var controller = new AuthController();
            var loginRequest = new LoginRequest
            {
                user = "SISTEMA",
                password = "candidato123"
            };

            var result = controller.Login(loginRequest) as JsonResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.Value?.GetType().GetProperty("status")?.GetValue(result.Value));
            Assert.NotNull(result.Value?.GetType().GetProperty("token")?.GetValue(result.Value));
        }

        [Fact]
        public void Login_InvalidCredentials_ReturnsUnauthorized()
        {
            var controller = new AuthController();
            var loginRequest = new LoginRequest
            {
                user = "InvalidUser",
                password = "InvalidPassword"
            };

            var result = controller.Login(loginRequest) as UnauthorizedResult;

            Assert.NotNull(result);
        }
    }
}
