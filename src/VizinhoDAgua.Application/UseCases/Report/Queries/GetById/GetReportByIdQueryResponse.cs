using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetById;

public class GetReportByIdQueryResponse
{
    public ReportEntity? Report { get; set; }

    public GetReportByIdQueryResponse(ReportEntity? report)
    {
        Report = report;
    }
}
