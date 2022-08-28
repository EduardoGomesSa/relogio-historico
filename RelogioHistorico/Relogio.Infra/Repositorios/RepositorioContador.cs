using Relogio.Infra.Entidades;
using Relogio.Infra.Interfaces;
using Relogio.Infra.Repositorios.Data;
using Relogio.Infra.Repositorios.Maps;

namespace Relogio.Infra.Repositorios
{
    public class RepositorioContador : RepositorioBase<Contador, ContadorMap> ,IRepositorioContador
    {
        public List<Contador> BuscarTodosEventos()
        {
            var query = "select * from cadastro.evento;";

            return DBHelper <Contador>.InstanciaNpgsql.GetQuery(query);
        }
    }
}
