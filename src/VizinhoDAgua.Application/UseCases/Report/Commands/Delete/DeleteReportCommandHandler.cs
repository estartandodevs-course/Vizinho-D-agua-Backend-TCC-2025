using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Delete
{
    public class DeleteReportCommandHandler : DeleteCommandHandler<ReportEntity, DeleteReportCommand>
    {
        public DeleteReportCommandHandler(IReportRepository reportRepository) : base(reportRepository)
        {
        }
    }
}
