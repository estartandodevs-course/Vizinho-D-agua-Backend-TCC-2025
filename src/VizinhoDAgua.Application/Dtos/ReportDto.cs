namespace VizinhoDAgua.Application.Dtos
{
    public record CreateReportRequest(
        string Description,
        string ReportType,
        string ReporterId,
        string PostalCode,
        string? StateCode,
        string? City,
        string? Neighborhood,
        string? Road,
        double? Lat,
        double? Lon
        ) {}

}