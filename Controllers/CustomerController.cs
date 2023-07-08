using Microsoft.AspNetCore.Mvc;
using MeuProjetoMVC.Models;
using MeuProjetoMVC.Helpers;


namespace MeuProjetoMVC.Controllers;
public class CustomerController : Controller
{

    [HttpPost]
    public IActionResult Register([FromBody] CustomerRequest customerRequest)
    {
        if (string.IsNullOrEmpty(customerRequest.name) || string.IsNullOrEmpty(customerRequest.cpf))
        {
            return ErrorHandling.BadRequest();
        }

        if (!customerRequest.ValidateCPF())
        {
            return ErrorHandling.BadRequest("CPF inválido, falha no registro.");
        }

        customerRequest.InsertCustomer();

        string messageResponse = "Pessoa cadastrada com sucesso, código "
                                    + customerRequest.cpf.Substring(0, 4);

        return Json(new { status = 201, message = messageResponse });
    }
}
