using VizinhoDAgua.Domain.Entities.Enum;

namespace VizinhoDAgua.Application.Dtos
{
    public record CreateAlertRequest(string Title, string Description, string PostalCode, string? City, 
        string? StateCode, string? Road, string? Neighborhood);
    
    public record UpdateAlertRequest(AlertStatus? Status, string? Title, string? Description, string? PostalCode, 
        string? City, string? StateCode, string? Road, string? Neighborhood);
}
