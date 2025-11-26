using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Update
{
    public class UpdateReportCommandHandler : UpdateCommandHandler<ReportEntity, UpdateReportCommand>
    {
        public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper)
            : base(reportRepository, mapper)
        {
        }
    }
}
