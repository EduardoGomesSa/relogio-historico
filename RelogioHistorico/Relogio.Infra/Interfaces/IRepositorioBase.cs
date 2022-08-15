using Relogio.Infra.Repositorios.Data;

namespace Relogio.Infra.Interfaces
{
    public interface IRepositorioBase<TEntity>
    {
        bool Excluir(TEntity entity);
        
        long Inserir(TEntity entity);

        TEntity BuscarPorId(long id);

        List<TEntity> BuscarTodos();

        void Commit();

        void Roolback();

        void IniciarTransacao();
    }
}
