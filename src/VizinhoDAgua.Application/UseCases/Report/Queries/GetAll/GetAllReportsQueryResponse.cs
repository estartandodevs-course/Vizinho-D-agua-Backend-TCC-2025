using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetAll;

public class GetAllReportsQueryResponse
{
    public IList<ReportEntity> Report { get; set; }
        
    public GetAllReportsQueryResponse(IList<ReportEntity> report)
    {
        Report = report;
    }
}
