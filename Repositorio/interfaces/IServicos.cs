using Exercicio_permissao1.Models;

namespace Exercicio_permissao1.Repositorio.interfaces;

public interface Iservico
{
    List<Administrador> todos();
    void Incluir(Administrador administrador);
    Administrador Atualizar(Administrador administrador);
    void Apagar(Administrador administrador);

}