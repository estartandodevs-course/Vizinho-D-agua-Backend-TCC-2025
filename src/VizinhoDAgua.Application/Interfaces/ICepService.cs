using VizinhoDAgua.Application.Dtos;

namespace VizinhoDAgua.Application.Interfaces
{
    public interface ICepService
    {
        Task<CepResponseDto?> GetAddressByCepAsync(string cep, CancellationToken cancellationToken);
    }
}
