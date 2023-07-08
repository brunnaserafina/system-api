using Xunit;
using MeuProjetoMVC.Models;

namespace MeuProjetoMVC.Tests
{
    public class LoginRequestTests
    {
        [Fact]
        public void SelectUserAndPassword_ValidUser_ReturnsIsValidUserTrue()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                user = "SISTEMA",
                password = "candidato123"
            };

            // Act
            loginRequest.SelectUserAndPassword();

            // Assert
            Assert.True(loginRequest.isValidUser);
        }

        [Fact]
        public void SelectUserAndPassword_InvalidUser_ReturnsIsValidUserFalse()
        {
            // Arrange
            var loginRequest = new LoginRequest
            {
                user = "invalid",
                password = "password"
            };

            // Act
            loginRequest.SelectUserAndPassword();

            // Assert
            Assert.False(loginRequest.isValidUser);
        }
    }
}
