using Xunit;
using MeuProjetoMVC.Models;

namespace MeuProjetoMVC.Tests
{
    public class CustomerRequestTests
    {
        [Fact]
        public void ValidateCPF_ValidCPF_ReturnsTrue()
        {
            // Arrange
            var customerRequest = new CustomerRequest
            {
                cpf = "79454064088"
            };

            // Act
            bool result = customerRequest.ValidateCPF();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ValidateCPF_InvalidCPF_ReturnsFalse()
        {
            // Arrange
            var customerRequest = new CustomerRequest
            {
                cpf = "12345678901"
            };

            // Act
            bool result = customerRequest.ValidateCPF();

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void ValidateCPF2_InvalidCPF_ReturnsFalse()
        {
            // Arrange
            var customerRequest = new CustomerRequest
            {
                cpf = "000000000"
            };

            // Act
            bool result = customerRequest.ValidateCPF();

            // Assert
            Assert.False(result);
        }
    }
}
