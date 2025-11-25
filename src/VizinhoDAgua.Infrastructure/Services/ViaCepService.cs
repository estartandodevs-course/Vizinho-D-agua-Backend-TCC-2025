using System.Net.Http.Json;
using System.Text.Json.Serialization;
using VizinhoDAgua.Domain.Dtos;
using VizinhoDAgua.Infrastructure.Services.Interfaces;


namespace VizinhoDAgua.Infrastructure.Services
{
    public class ViaCepService : ICepService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CepResponseDto?> GetAddressByCepAsync(string cep, CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync($"{cep}/json/", cancellationToken);

            if (!response.IsSuccessStatusCode)
                return null;

            ViaCepResponse? data = await response.Content.ReadFromJsonAsync<ViaCepResponse>(cancellationToken);

            if (data == null)
                return null;

            return new CepResponseDto(
               Road: data.Road,
               Neighborhood: data.Neighborhood,
               City: data.City,
               StateCode: data.StateCode,
               PostalCode: data.PostalCode
            );

        }
    }

    public sealed record ViaCepResponse(
        [property: JsonPropertyName("cep")] string? PostalCode,
        [property: JsonPropertyName("logradouro")] string? Road,
        [property: JsonPropertyName("bairro")] string? Neighborhood,
        [property: JsonPropertyName("localidade")] string? City,
        [property: JsonPropertyName("uf")] string? StateCode
    );
}
