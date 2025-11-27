namespace VizinhoDAgua.Application.Dtos
{
    public record CreateReportRequest(string Description, string WaterCompanyRelated, string ReporterId, string ReportType, string PostalCode, 
        string? StateCode, string? City, string? Neighborhood, string? Road, double? Lat, double? Lon) {}
    
    public record UpdateReportRequest(string? Description, string? ReportType, string? PostalCode, 
        string? StateCode, string? City, string? Neighborhood, string? Road, double? Lat, double? Lon) {}
}
