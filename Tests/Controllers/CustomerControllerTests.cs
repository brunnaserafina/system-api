using Xunit;
using MeuProjetoMVC.Controllers;
using MeuProjetoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoMVC.Tests
{
    public class CustomerControllerTests
    {
        [Fact]
        public void Register_ValidCustomer_ReturnsCreatedResult()
        {
            var customerRequest = new CustomerRequest
            {
                name = "Maria Silva",
                cpf = "19934651033"
            };

            var controller = new CustomerController();

            var result = controller.Register(customerRequest) as JsonResult;

            Assert.NotNull(result);
            Assert.Equal(201, result?.Value?.GetType().GetProperty("status")?.GetValue(result.Value));
            Assert.Equal("Pessoa cadastrada com sucesso, código 1993", result?.Value?.GetType().GetProperty("message")?.GetValue(result.Value));
        }

        [Fact]
        public void Register_InvalidCustomer_ReturnsBadRequest()
        {
            var customerController = new CustomerController();
            var invalidCustomer = new CustomerRequest { name = "", cpf = "" };

            var result = customerController.Register(invalidCustomer) as BadRequestResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
        }

        [Fact]
        public void Register_InvalidCPF_ReturnsBadRequestWithMessage()
        {
            var customerRequest = new CustomerRequest
            {
                name = "Maria Silva",
                cpf = "12345678901"
            };

            var controller = new CustomerController();

            var result = controller.Register(customerRequest) as ObjectResult;

            Assert.NotNull(result);
            Assert.Equal(400, result.StatusCode);
            Assert.Equal("CPF inválido, falha no registro.", result.Value);
        }
    }
}