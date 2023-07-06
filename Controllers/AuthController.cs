using Microsoft.AspNetCore.Mvc;
using MeuProjetoMVC.Models;

namespace MeuProjetoMVC.Controllers;

public class AuthController : Controller
{   

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {
        if(loginRequest.user != "SISTEMA" || loginRequest.password != "candidato123"){
            return NotFound();
        }        
        
        string token = GenerateToken();
        return Json(new { status = 200, token });
    }

    private string GenerateToken(){
        return "auth-token";
    }

}
