using Relogio.Application.Commands;

namespace Relogio.Application.Interfaces
{
    public interface IEventoHandler
    {
        bool AdicionarEvento(AdicionarEvento adicionarEvento);
        bool ExcluirEvento(DeletarEvento deletarEvento);
    }
}
