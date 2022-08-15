using Relogio.Application.Interfaces;
using Relogio.Application.Queries;
using Relogio.Infra.Interfaces;

namespace Relogio.Application.Handler
{
    public class ContadorHandler : IContadorHandler
    {
        private readonly IContadorService _contadorService;

        public ContadorHandler(IContadorService contadorService)
        {
            this._contadorService = contadorService;
        }

        public string ObterTempoEmAnos(ContadorTempo contadorTempo)
        {
            var tempoCalculado = _contadorService.CalcularTempoEmAnos(contadorTempo.DataEvento);

            return tempoCalculado;
        }

        public string ObterTempoEmDias(ContadorTempo contadorTempo)
        {
            var tempoCalculado = _contadorService.CalcularTempoEmDias(contadorTempo.DataEvento);

            return tempoCalculado;
        }

        public string ObterTempoEmMeses(ContadorTempo contadorTempo)
        {
            var tempoCalculado = _contadorService.CalcularTempoEmMeses(contadorTempo.DataEvento);

            return tempoCalculado;
        }
    }
}
