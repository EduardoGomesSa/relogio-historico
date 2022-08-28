using MediatR;
using Microsoft.AspNetCore.Mvc;
using Relogio.Application.Handler;
using Relogio.Application.Interfaces;
using Relogio.Application.Queries;

namespace Relogio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContadorController : ControllerBase
    {
        private readonly IContadorHandler _contadorHandler;

        public ContadorController(IContadorHandler contadorHandler)
        {
            _contadorHandler = contadorHandler;
        }

        [HttpGet("ObterTempoEmDias")]
        public IActionResult ObterTempoEmDias([FromQuery] ContadorTempo contadorTempo)
        {
            return Ok(_contadorHandler.ObterTempoEmDias(contadorTempo));
        }

        [HttpGet("ObterTempoEmMeses")]
        public IActionResult ObterTempoEmMeses([FromQuery] ContadorTempo contadorTempo)
        {
            return Ok(_contadorHandler.ObterTempoEmMeses(contadorTempo));
        }

        [HttpGet("ObterTempoEmAnos")]
        public IActionResult ObterTempoEmAnos([FromQuery] ContadorTempo contadorTempo)
        {
            return Ok(_contadorHandler.ObterTempoEmAnos(contadorTempo));
        }
    }
}
