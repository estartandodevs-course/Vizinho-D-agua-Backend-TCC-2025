using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetById;

public class GetReportByIdQueryHandler 
    : GetByIdQueryHandler<ReportEntity, GetReportByIdQuery, GetReportByIdQueryResponse>
{
    public GetReportByIdQueryHandler(IReportRepository reportRepository, IMapper mapper)
        : base(reportRepository, mapper)
    {
    }
}
