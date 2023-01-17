using Exercicio_permissao1.Models;
using Exercicio_permissao1.Repositorio.interfaces;
namespace Exercicio_permissao1.ModelViews;

public class RepositorioAdm : Iservico
{
    private static List<Administrador> lista = new List<Administrador>();
    public void Apagar(Administrador administrador)
    {
        lista.Remove(administrador);
    }

    public Administrador Atualizar(Administrador administrador)
    {
         if(administrador.Id == 0) throw new Exception("Id não pode ser zero");

        var administradorDb = lista.Find(a => a.Id == administrador.Id);
        if(administradorDb is null)
        {
            throw new Exception("O administrador informado não existe");
        }

        administradorDb.Nome = administrador.Nome;
        administradorDb.Login = administrador.Login;
        administradorDb.Senha = administrador.Senha;
        administradorDb.Regra = administrador.Regra;
        return administradorDb;
    }

    public void Incluir(Administrador administrador)
    {
         lista.Add(administrador);
    }

    public List<Administrador> todos()
    {
        return lista;
    }
}