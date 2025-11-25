namespace VizinhoDAgua.Application.Dtos
{
    public sealed record CepResponseDto(
        string? Road, string? Neighborhood, string? City, string? StateCode, string? PostalCode
    );
}
