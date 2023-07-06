using Microsoft.AspNetCore.Mvc;
using MeuProjetoMVC.Models;

namespace MeuProjetoMVC.Controllers;

public class CustomerController : Controller
{

    [HttpPost]
    public IActionResult Register([FromBody] CustomerRequest customerRequest)
    {

        if (string.IsNullOrEmpty(customerRequest.name) || string.IsNullOrEmpty(customerRequest.cpf))
        {
            return BadRequest();
        }

        string messageResponse = "Pessoa cadastrada com sucesso, código "
                                    + customerRequest.cpf.Substring(0, 4);

        return Json(new { status = 201, messageResponse });
    }
}
