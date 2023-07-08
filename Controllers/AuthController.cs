using Microsoft.AspNetCore.Mvc;
using MeuProjetoMVC.Models;
using MeuProjetoMVC.Helpers;


namespace MeuProjetoMVC.Controllers;

public class AuthController : Controller
{

    [HttpPost]
    public IActionResult Login([FromBody] LoginRequest loginRequest)
    {   
        //Validation without database:
        // if (loginRequest.user != "SISTEMA" || loginRequest.password != "candidato123")
        // {
        //      return Unauthorized();
        // }

        //Validation with database:
        loginRequest.ValidateUserAndPassword();

        if(!loginRequest.isValidUser){
            return ErrorHandling.Unauthorized();
        }

        string token = TokenHelper.GenerateToken(loginRequest.user);
        loginRequest.InsertTokenInSession(token);
        
        return Json(new { status = 200, token });
    }
}
