using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommandHandler
        : CreateCommandHandler<ReportEntity, CreateReportCommand, CreateReportCommandResponse>
    {
        public CreateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
            : base(reportRepository, mapper)
        {
        }
    }
}
