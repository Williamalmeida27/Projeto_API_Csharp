using Exercicio_permissao1.ModelViews;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_permissao1.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [Route("/")]
    [HttpGet]
    public ActionResult Index()
    {
        return StatusCode(200, new Home{
            Mensagem = "Bem vindo a minha API"
        });
    }
}