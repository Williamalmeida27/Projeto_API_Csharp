using Exercicio_permissao1.Repositorio.interfaces;
using Exercicio_permissao1.Models;
using MySqlConnector;

namespace Exercicio_permissao1.ModelViews;

public class RepositorioMysql : Iservico
{
    public RepositorioMysql()
    {
        conexao = Environment.GetEnvironmentVariable("DB_URL");
        if(conexao is null) conexao ="Server=localhost;Database=exercicio_permissao;User=root;Password=root";

    }
    private string? conexao = null;

    public List<Administrador> todos()
    {
        var lista = new List<Administrador>();
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"select * from administrador";

            var command = new MySqlCommand(query, conn);
            var dr = command.ExecuteReader();
            while(dr.Read())
            {
                lista.Add(new Administrador{
                    Id = Convert.ToInt32(dr["id"]),
                    Nome = dr["nome"].ToString() ?? "",
                    Login = dr["login"].ToString() ?? "",
                    Senha = dr["senha"].ToString() ?? "",
                    Regra = dr["regra"].ToString() ?? "",
                });
            }

            conn.Close();
        }

        return lista;
    }



    public void Apagar(Administrador administrador)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"delete from administrador where id = @id;";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", administrador.Id));
            command.ExecuteNonQuery();
            conn.Close();
        }
    }

    public Administrador Atualizar(Administrador administrador)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"update administrador set nome=@nome,login=@login,senha=@senha,regra=@regra where id = @id;";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@id", administrador.Id));
            command.Parameters.Add(new MySqlParameter("@nome", administrador.Nome));
            command.Parameters.Add(new MySqlParameter("@login", administrador.Login));
            command.Parameters.Add(new MySqlParameter("@senha", administrador.Senha));
            command.Parameters.Add(new MySqlParameter("@regra", administrador.Regra));
            command.ExecuteNonQuery();

            conn.Close();
        }

        return administrador;
    }

    public void Incluir(Administrador administrador)
    {
        using(var conn = new MySqlConnection(conexao))
        {
            conn.Open();
            var query = $"insert into administrador(nome,login,senha,regra)values(@nome,@login,@senha,@regra)";
            var command = new MySqlCommand(query, conn);
            command.Parameters.Add(new MySqlParameter("@nome", administrador.Nome));
            command.Parameters.Add(new MySqlParameter("@login", administrador.Login));
            command.Parameters.Add(new MySqlParameter("@senha", administrador.Senha));
            command.Parameters.Add(new MySqlParameter("@regra", administrador.Regra));
            command.ExecuteNonQuery();

            conn.Close();
        }
    }
}