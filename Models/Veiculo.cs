using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_permissao1.Models;

[Table("veiculo")]
public partial class Veiculo
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("nome")]
    [StringLength(150)]
    public string Nome { get; set; } = null!;

    [Column("descricao")]
    [StringLength(100)]
    public string Descricao { get; set; } = null!;

    [Column("marca")]
    [StringLength(100)]
    public string Marca { get; set; } = null!;

    [Column("modelo")]
    [StringLength(100)]
    public string Modelo { get; set; } = null!;

    [Column("ano")]
    public int? Ano { get; set; }
}
