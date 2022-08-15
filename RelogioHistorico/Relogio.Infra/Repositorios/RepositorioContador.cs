using Relogio.Infra.Entidades;
using Relogio.Infra.Interfaces;
using Relogio.Infra.Repositorios.Maps;

namespace Relogio.Infra.Repositorios
{
    public class RepositorioContador : RepositorioBase<Contador, ContadorMap> ,IRepositorioContador
    {

    }
}
