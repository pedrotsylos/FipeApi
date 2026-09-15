using System.Net.Http.Headers;
using System.Text.Json;
using FipeApi.Models;

namespace FipeApi.Services
{
    public class FipeService
    {
        private readonly HttpClient _httpClient;

        public FipeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<TabelaReferencia>> ConsultarTabelasReferencia(int codigoTipoVeiculo)
        {
            var url = "https://veiculos.fipe.org.br/api/veiculos/ConsultarTabelaDeReferencia";

            using var content = new MultipartFormDataContent();

            content.Add(new StringContent(codigoTipoVeiculo.ToString()), "codigoTipoVeiculo");

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = content;

            request.Headers.UserAgent.ParseAdd("PostmanRuntime/7.54.0");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"A API FIPE retornou {(int)response.StatusCode} {response.StatusCode}.\n\n{erro}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<List<TabelaReferencia>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return resultado ?? new List<TabelaReferencia>();
        }

        public async Task<List<Marca>> ConsultarMarcas(int codigoTabelaReferencia,int codigoTipoVeiculo)
        {
            var url = "https://veiculos.fipe.org.br/api/veiculos/ConsultarMarcas";

            var dados = new Dictionary<string, string>
                {
                    { "codigoTabelaReferencia", codigoTabelaReferencia.ToString() },
                    { "codigoTipoVeiculo", codigoTipoVeiculo.ToString() }
                };

            using var content = new FormUrlEncodedContent(dados);

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = content;

            request.Headers.UserAgent.ParseAdd("PostmanRuntime/7.54.0");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"A API FIPE retornou {(int)response.StatusCode} {response.StatusCode}.\n\n{erro}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<List<Marca>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return resultado ?? new List<Marca>();
        }

        public async Task<List<Modelo>> ConsultarModelos(int codigoTabelaReferencia, int codigoMarca, int codigoTipoVeiculo)
        {
            var url = "https://veiculos.fipe.org.br/api/veiculos/ConsultarModelos";

            var dados = new Dictionary<string, string>
                {
                    { "codigoTabelaReferencia", codigoTabelaReferencia.ToString() },
                    { "codigoMarca", codigoMarca.ToString() },
                    { "codigoTipoVeiculo", codigoTipoVeiculo.ToString() }
                };

            using var content = new FormUrlEncodedContent(dados);

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = content;

            request.Headers.UserAgent.ParseAdd("PostmanRuntime/7.54.0");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"A API FIPE retornou {(int)response.StatusCode} {response.StatusCode}.\n\n{erro}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ModeloResponse>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return resultado?.Modelos ?? new List<Modelo>();
        }

        public async Task<List<AnoModelo>> ConsultarAnoModelo(int codigoTabelaReferencia, int codigoMarca, int codigoModelo, int codigoTipoVeiculo)
        {
            var url = "https://veiculos.fipe.org.br/api/veiculos/ConsultarAnoModelo";

            var dados = new Dictionary<string, string>
                {
                    { "codigoTabelaReferencia", codigoTabelaReferencia.ToString() },
                    { "codigoMarca", codigoMarca.ToString() },
                    { "codigoModelo", codigoModelo.ToString() },
                    { "codigoTipoVeiculo", codigoTipoVeiculo.ToString() }
                };

            using var content = new FormUrlEncodedContent(dados);

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = content;

            request.Headers.UserAgent.ParseAdd("PostmanRuntime/7.54.0");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"A API FIPE retornou {(int)response.StatusCode} {response.StatusCode}.\n\n{erro}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<List<AnoModelo>>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return resultado ?? new List<AnoModelo>();
        }

        public async Task<ValorFIPE?> ConsultarValor(int codigoTabelaReferencia, int codigoMarca, int codigoModelo, int codigoTipoVeiculo, int anoModelo, int codigoTipoCombustivel, string tipoConsulta)
        {
            var url = "https://veiculos.fipe.org.br/api/veiculos/ConsultarValorComTodosParametros";

            var dados = new Dictionary<string, string>
                {
                    { "codigoTabelaReferencia", codigoTabelaReferencia.ToString() },
                    { "codigoMarca", codigoMarca.ToString() },
                    { "codigoModelo", codigoModelo.ToString() },
                    { "codigoTipoVeiculo", codigoTipoVeiculo.ToString() },
                    { "anoModelo", anoModelo.ToString() },
                    { "codigoTipoCombustivel", codigoTipoCombustivel.ToString() },
                    { "tipoConsulta", tipoConsulta }
                };

            using var content = new FormUrlEncodedContent(dados);

            using var request = new HttpRequestMessage(HttpMethod.Post, url);

            request.Content = content;

            request.Headers.UserAgent.ParseAdd("PostmanRuntime/7.54.0");
            request.Headers.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await _httpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                var erro = await response.Content.ReadAsStringAsync();

                throw new HttpRequestException(
                    $"A API FIPE retornou {(int)response.StatusCode} {response.StatusCode}.\n\n{erro}");
            }

            var json = await response.Content.ReadAsStringAsync();

            var resultado = JsonSerializer.Deserialize<ValorFIPE>(
                json,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return resultado;
        }

    }
}