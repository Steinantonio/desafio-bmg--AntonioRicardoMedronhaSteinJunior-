using Microsoft.AspNetCore.Mvc;
using PromoIphones.Dtos;
using PromoIphones.Interfaces;

namespace PromoIphones.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoService _promocaoService;

        public PromocaoController(IPromocaoService promocaoService)
        {
            _promocaoService = promocaoService;
        }

        [HttpPost("comprar")]
        public async Task<ActionResult<ResultadoCompraDto>> Comprar([FromBody] int quantidade)
        {
            var resultado = await _promocaoService.ComprarIphonePromocao(quantidade);
            return Ok(resultado);
        }

        [HttpGet("status")]
        public ActionResult<Dictionary<int, int>> Status()
        {
            var status = _promocaoService.ObterStatusVendas();
            return Ok(status);
        }
    }
}