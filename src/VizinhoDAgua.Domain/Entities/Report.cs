namespace VizinhoDAgua.Domain.Entities
{
    public class Report : Entity
    {
        public Guid ReporterId { get; private set; }
        public User? Reporter { get; private set; }
        
        public string? Description { get; private set; }
        public string? Status { get; private set; }
        public string? ReportType { get; private set; }
        public Location? PostalCode { get; private set; }
        public List<string>? Attachments { get; private set; } = [];
        
        public Report() { } // EF Core

        public Report(Guid reporterId, User? reporter, string? description, string? status, string? reportType, 
            Location? postalCode, List<string>? attachments = null)
        {
            ReporterId = reporterId;
            Reporter = reporter;
            Description = description;
            Status = status;
            ReportType = reportType;
            PostalCode = postalCode;
            if (attachments != null) Attachments = attachments;
        }
    }
}
