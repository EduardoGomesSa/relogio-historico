using Microsoft.AspNetCore.Mvc;
using Relogio.Application.Commands;
using Relogio.Application.Interfaces;

namespace Relogio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        private readonly IEventoHandler _eventoHandler;

        public EventoController(IEventoHandler eventoHandler)
        {
            _eventoHandler = eventoHandler;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AdicionarEvento adicionarEvento)
        {
            try
            {
                var eventoAdicionado = _eventoHandler.AdicionarEvento(adicionarEvento);

                if (eventoAdicionado) return Ok(eventoAdicionado);

                return BadRequest(eventoAdicionado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] DeletarEvento deletarEvento)
        {
            try
            {
                var eventoDeletado = _eventoHandler.ExcluirEvento(deletarEvento);

                if (eventoDeletado) return Ok(eventoDeletado);

                return BadRequest(eventoDeletado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
