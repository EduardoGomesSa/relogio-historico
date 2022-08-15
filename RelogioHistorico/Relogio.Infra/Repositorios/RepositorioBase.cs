using DapperExtensions;
using Relogio.Infra.Interfaces;
using Relogio.Infra.Repositorios.Data;
using System.Reflection;

namespace Relogio.Infra.Repositorios
{
    public class RepositorioBase<TEntity, TMap> : IRepositorioBase<TEntity>
        where TEntity : class
    {
        public RepositorioBase()
        {
            DapperExtensions.DapperExtensions.SetMappingAssemblies(new List<Assembly> { typeof(TMap).Assembly });
        }

        public virtual bool Excluir(TEntity entity)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Excluir(entity);
        }

        public virtual long Inserir(TEntity entity)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Inserir(entity);
        }

        public virtual TEntity BuscarPorId(long id)
        {
            return DBHelper<TEntity>.InstanciaNpgsql.Get(id);

        }

        public virtual List<TEntity> BuscarTodos()
        {
            return DBHelper<TEntity>.InstanciaNpgsql.GetAll();

        }

        public void Commit()
        {
            DBHelper<TEntity>.InstanciaNpgsql.CommitTransaction();
        }

        public void Roolback()
        {
            DBHelper<TEntity>.InstanciaNpgsql.RollbackTransaction();
        }

        public void IniciarTransacao()
        {
            DBHelper<TEntity>.InstanciaNpgsql.BeginTransaction();
        }
    }
}
