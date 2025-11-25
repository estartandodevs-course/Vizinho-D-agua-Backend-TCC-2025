using VizinhoDAgua.Domain.Dtos;

namespace VizinhoDAgua.Infrastructure.Services.Interfaces
{
    public interface ICepService
    {
        Task<CepResponseDto?> GetAddressByCepAsync(string cep, CancellationToken cancellationToken);
    }
}
