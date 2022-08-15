using Npgsql;
using System.Data;

namespace Relogio.Infra.Repositorios.Data
{
    public class PostgresSQL : FactoryConnection
    {
        public IDbConnection Create()
        {
            DapperExtensions.DapperExtensions.SqlDialect = new DapperExtensions.Sql.PostgreSqlDialect();

            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "postgres";
            sb.Database = "relogio_historico";
            sb.Port = 5432;
            sb.Timeout = 90;

            var conexao = new NpgsqlConnection(sb.ConnectionString);
            try
            {
                conexao.Open();
            }
            catch(Exception ex)
            {
                throw new ApplicationException("Erro ao conectar no banco.", ex);
            }

            return conexao;
        }
    }

    public interface FactoryConnection
    {
        IDbConnection Create();
    }
}
