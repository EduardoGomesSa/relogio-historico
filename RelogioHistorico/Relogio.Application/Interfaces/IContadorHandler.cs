using Relogio.Application.Queries;

namespace Relogio.Application.Interfaces
{
    public interface IContadorHandler
    {
        string ObterTempoEmDias(ContadorTempo contadorTempo);
        string ObterTempoEmMeses(ContadorTempo contadorTempo);
        string ObterTempoEmAnos(ContadorTempo contadorTempo);
    }
}
