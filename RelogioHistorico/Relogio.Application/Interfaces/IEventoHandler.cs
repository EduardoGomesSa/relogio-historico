using Relogio.Application.Commands;
using Relogio.Application.Queries;

namespace Relogio.Application.Interfaces
{
    public interface IEventoHandler
    {
        bool AdicionarEvento(AdicionarEvento adicionarEvento);
        bool ExcluirEvento(DeletarEvento deletarEvento);
        List<ContadorTempoEvento> BuscarTodos();
    }
}
