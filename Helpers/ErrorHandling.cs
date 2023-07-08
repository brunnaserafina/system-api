using Microsoft.AspNetCore.Mvc;

namespace MeuProjetoMVC.Helpers
{
    public static class ErrorHandling
    {
        public static IActionResult Unauthorized()
        {
            return new UnauthorizedResult();
        }

        public static IActionResult BadRequest(string? message = null)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new BadRequestResult();
            }

            return new BadRequestObjectResult(message);
        }
    }
}