using FipeApi.Models;
using FipeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FipeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FipeController : ControllerBase
    {
        private readonly FipeService _fipeService;

        public FipeController(FipeService fipeService)
        {
            _fipeService = fipeService;
        }

        [HttpGet("tabelas")]
        public async Task<IActionResult> ConsultarTabelas(int codigoTipoVeiculo)
        {
            var resultado = await _fipeService.ConsultarTabelasReferencia(codigoTipoVeiculo);

            return Ok(resultado);
        }

        [HttpGet("marcas")]
        public async Task<IActionResult> ConsultarMarcas(int codigoTabelaReferencia, int codigoTipoVeiculo)
        {
            var resultado = await _fipeService.ConsultarMarcas(codigoTabelaReferencia, codigoTipoVeiculo);

            return Ok(resultado);
        }

        [HttpGet("modelos")]
        public async Task<IActionResult> ConsultarModelos(int codigoTabelaReferencia, int codigoMarca, int codigoTipoVeiculo)
        {
            var resultado = await _fipeService.ConsultarModelos(
                codigoTabelaReferencia,
                codigoMarca,
                codigoTipoVeiculo);

            return Ok(resultado);
        }

        [HttpGet("ano-modelo")]
        public async Task<IActionResult> ConsultarAnoModelo(int codigoTabelaReferencia, int codigoMarca, int codigoModelo, int codigoTipoVeiculo)
        {
            var resultado = await _fipeService.ConsultarAnoModelo(
                codigoTabelaReferencia,
                codigoMarca,
                codigoModelo,
                codigoTipoVeiculo);

            return Ok(resultado);
        }

        [HttpGet("valor")]
        public async Task<IActionResult> ConsultarValor(int codigoTabelaReferencia, int codigoMarca, int codigoModelo, int codigoTipoVeiculo, int anoModelo, int codigoTipoCombustivel, string tipoConsulta)
        {
            var resultado = await _fipeService.ConsultarValor(
                codigoTabelaReferencia,
                codigoMarca,
                codigoModelo,
                codigoTipoVeiculo,
                anoModelo,
                codigoTipoCombustivel,
                tipoConsulta);

            return Ok(resultado);
        }

    }
}