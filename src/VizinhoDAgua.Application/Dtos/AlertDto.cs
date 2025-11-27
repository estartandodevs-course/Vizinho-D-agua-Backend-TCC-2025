namespace VizinhoDAgua.Application.Dtos
{
    public record CreateAlertRequest(string Description, string PostalCode, string? City, string? StateCode, string? Road, string? Neighborhood);
    public record UpdateAlertStatusRequest(int Status);
}
