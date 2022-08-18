using Relogio.Application.Commands;
using Relogio.Application.Interfaces;
using Relogio.Application.Queries;
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

        public List<ContadorTempoEvento> BuscarTodos()
        {
            var listaContadores = new List<ContadorTempoEvento>();

            foreach (var contador in _repositorioContador.BuscarTodosEventos())
            {
                var calculoTempo = _contadorService.CalcularTempoEmDias(contador.DataEvento);

                listaContadores.Add(this.ConverterParaContadorTempoEvento(contador, calculoTempo));
            }

            return listaContadores;
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

        private ContadorTempoEvento ConverterParaContadorTempoEvento(Contador contador, string tempoCalculado)
        {
            return new ContadorTempoEvento
            {
                Id = contador.Id,
                Nome = contador.Nome,
                Descricao = contador.Descricao,
                DataEvento = contador.DataEvento,
                TempoCalculado = tempoCalculado
            };
        }
    }
}
