using Microsoft.AspNetCore.Mvc;
using NotasApi.DTOs;
using NotasApi.Services;

namespace NotasApi.Controllers
{
    [ApiController]
    [Route("api/notas")]
    public class NotasController : ControllerBase
    {   
        private readonly INotaFiscalService _service;

        public NotasController(INotaFiscalService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Cadastrar([FromBody] CriarNotaFiscalDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var resultado = _service.Cadastrar(dto);
            return Ok(resultado);
        }

        [HttpGet]
        public IActionResult ListarTodas()
        {
            var notas = _service.ListarTodas();
            return Ok(notas);
        }

        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult LimparTodas()
        {
            _service.LimparTodas();
            return NoContent(); // HTTP 204
        }
    }
}