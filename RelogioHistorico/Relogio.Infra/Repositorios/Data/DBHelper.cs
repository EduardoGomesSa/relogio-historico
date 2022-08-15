using DapperExtensions;
using Npgsql;
using System.Data;
using static Dapper.SqlMapper;

namespace Relogio.Infra.Repositorios.Data
{
    public class DBHelper <TEntity> where TEntity : class
    {
        private IDbConnection _conexaoPadrao = null;
        private IDbTransaction _transacao = null;
        private readonly FactoryConnection factory;

        public static DBHelper<TEntity> InstanciaNpgsql = new DBHelper<TEntity>(new PostgresSQL());

        private DBHelper(FactoryConnection factory)
        {
            this.factory = factory;
        }

        private IDbConnection ObtenhaConexaoPadrao()
        {    //TODO implementar varias conexoes
            if (ConexaoPadraoEstaFechada())
            {
                _conexaoPadrao = factory.Create();
            }
            return _conexaoPadrao;
        }

        private bool ConexaoPadraoEstaFechada()
        {
            return _conexaoPadrao == null || _conexaoPadrao.State == ConnectionState.Closed;
        }

        public TEntity Get(Int64 id)
        {
            var conexao = this.ObtenhaConexaoPadrao();

            try
            {
                return conexao.Get<TEntity>(new { Id = id }, _transacao);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> GetAll()
        {
            var conexao = this.ObtenhaConexaoPadrao();

            try
            {
                return conexao.Get<List<TEntity>>(_transacao);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public Int64 Get(string query, object value = null)
        {
            var conexao = this.ObtenhaConexaoPadrao();

            try
            {
                return conexao.ExecuteScalar<Int64>(query, value);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public List<TEntity> GetQuery(string query)
        {
            var conexao = this.ObtenhaConexaoPadrao();

            try
            {
                var lista = conexao.Query<TEntity>(query);
                return lista.ToList();
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public Int64 Inserir(TEntity entity)
        {
            var conexao = this.ObtenhaConexaoPadrao();
            Int64 resultado = 0;
            try
            {
                return conexao.Insert<TEntity>(entity, _transacao);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
            return resultado;
        }

        public bool Excluir(TEntity entity)
        {
            var conexao = this.ObtenhaConexaoPadrao();

            try
            {
                return conexao.Delete(entity, _transacao);
            }
            catch (NpgsqlException npgEx)//FbException fbex)
            {
                //Tratamento especial para erros do tipo: "Error reading data from the connection."
                if (npgEx.ErrorCode == 08000)
                {
                    throw new ApplicationException("O servidor de banco de dados não está respondendo. Por favor, verifique a conexão com o servidor!");
                }
                //Tratamento especial para erros do tipo: "Foreign key references are present for the record."
                if (npgEx.ErrorCode == 23503)
                {
                    throw new ApplicationException("Não é possível de executar a operação!\nPois, ela viola a INTEGRIDADE do seu banco de dados!\n\n" + npgEx.Message);
                }
                throw;
            }
            catch
            {
                throw;
            }
        }

        public void BeginTransaction()
        {
            if (this._transacao == null)
            {
                IDbConnection conexao = this.ObtenhaConexaoPadrao();
                this._transacao = conexao.BeginTransaction(IsolationLevel.RepeatableRead);
            }
        }

        public void RollbackTransaction()
        {
            if (this._transacao != null)
            {
                this._transacao.Rollback();
                this._transacao.Dispose();
                this._transacao = null;
            }
        }

        public void CommitTransaction()
        {
            if (this._transacao != null)
            {
                this._transacao.Commit();
                this._transacao.Dispose();
                this._transacao = null;
            }
        }
    }
}
