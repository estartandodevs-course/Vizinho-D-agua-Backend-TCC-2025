using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Queries.GetAll
{
    public class GetAllReportsQueryHandler 
        : GetAllQueryHandler<ReportEntity, GetAllReportsQuery, GetAllReportsQueryResponse>
    {
        public GetAllReportsQueryHandler(IReportRepository reportRepository, IMapper mapper) 
            : base(reportRepository, mapper)
        {
        }   
    }
}
