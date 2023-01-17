using System;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_permissao1.Models;

public record class Administrador
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    
    public string Login { get; set; } = null!;

    
    public string Senha { get; set; } = null!;

    
    public string Regra { get; set; } = null!;
}
