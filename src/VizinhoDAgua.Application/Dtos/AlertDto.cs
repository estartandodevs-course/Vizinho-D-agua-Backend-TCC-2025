namespace VizinhoDAgua.Application.Dtos
{
    public record CreateAlertRequest(string Description, string PostalCode, string? City, string? StateCode );
    public record UpdateAlertStatusRequest(int Status);
}
