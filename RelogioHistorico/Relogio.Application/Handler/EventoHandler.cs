using Relogio.Application.Commands;
using Relogio.Application.Interfaces;
using Relogio.Infra.Entidades;
using Relogio.Infra.Interfaces;

namespace Relogio.Application.Handler
{
    public class EventoHandler : IEventoHandler
    {
        private readonly IContadorService _contadorService;
        private readonly IRepositorioContador _repositorioContador;

        public EventoHandler(IContadorService contadorService, IRepositorioContador repositorioContador)
        {
            this._contadorService = contadorService;
            _repositorioContador = repositorioContador;
        }

        public bool AdicionarEvento(AdicionarEvento adicionarEvento)
        {
            var evento = this.ConverterParaContador(adicionarEvento);

            return _repositorioContador.Inserir(evento) > 0;
        }

        public bool ExcluirEvento(DeletarEvento deletarEvento)
        {
            var evento = _repositorioContador.BuscarPorId(deletarEvento.Id);

            return _repositorioContador.Excluir(evento);
        }

        private Contador ConverterParaContador(AdicionarEvento adicionarEvento)
        {
            return new Contador(
                    0,
                    adicionarEvento.Nome,
                    adicionarEvento.Descricao,
                    adicionarEvento.DataEvento
                );
        }
    }
}
