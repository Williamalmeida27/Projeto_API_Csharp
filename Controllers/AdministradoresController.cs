using Exercicio_permissao1.Repositorio.interfaces;
using Exercicio_permissao1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercicio_permissao1.Controllers;

[Route("administradores")]
public class AdministradoresController : ControllerBase
{
    private Iservico _servico;
    public AdministradoresController(Iservico servico)
    {
        _servico = servico;
    }
    // GET: Administradores
    [HttpGet("")]
    public IActionResult Index()
    {
        var administradores = _servico.todos();
        return StatusCode(200, administradores);
    }

    [HttpGet("{id}")]
    public IActionResult Details([FromRoute] int id)
    {
       var administrador = _servico.todos().Find(a => a.Id == id);

        return StatusCode(200, administrador);
    }

    
    // POST: Administradores
    [HttpPost("")]
    public IActionResult Create([FromBody] Administrador administrador)
    {
        _servico.Incluir(administrador);
        return StatusCode(201, administrador);
    }


    // PUT: Administradores/5
    [HttpPut("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] Administrador administrador)
    {
        if (id != administrador.Id)
        {
            return StatusCode(400, new {
                Mensagem = "O Id do administrador precisa bater com o id da URL"
            });
        }

        var administradorDb = _servico.Atualizar(administrador);

        return StatusCode(200, administradorDb);
    }

    // POST: Administradores/5
    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var administradorDb = _servico.todos().Find(a => a.Id == id);
        if(administradorDb is null)
        {
            return StatusCode(404, new {
                Mensagem = "O administrador informado não existe"
            });
        }

        _servico.Apagar(administradorDb);

        return StatusCode(204);
    }
}