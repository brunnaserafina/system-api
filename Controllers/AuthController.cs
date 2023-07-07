using Microsoft.AspNetCore.Mvc;
using MeuProjetoMVC.Models;
using MeuProjetoMVC.Helpers;


namespace MeuProjetoMVC.Controllers;

public class AuthController : Controller
{

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if (loginRequest.user != "SISTEMA" || loginRequest.password != "candidato123")
        {
            return BadRequest();
        }

        string token = TokenHelper.GenerateToken(loginRequest.user);
        return Json(new { status = 200, token });
    }
}
