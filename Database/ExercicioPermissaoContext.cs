using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Exercicio_permissao1.Models;

public partial class ExercicioPermissaoContext : DbContext
{
    public ExercicioPermissaoContext()
    {
    }

    public ExercicioPermissaoContext(DbContextOptions<ExercicioPermissaoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrador> Administradors { get; set; } = default!;

    public virtual DbSet<Veiculo> Veiculos { get; set; } = default!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseMySql("server=localhost;database=exercicio_permissao;user=root;password=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Administrador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Veiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
