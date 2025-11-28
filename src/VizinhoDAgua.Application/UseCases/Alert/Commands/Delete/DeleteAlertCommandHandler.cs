using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Delete
{
    public class DeleteAlertCommandHandler : DeleteCommandHandler<AlertEntity, DeleteAlertCommand>
    {
        public DeleteAlertCommandHandler(IAlertRepository reportRepository) : base(reportRepository)
        {
        }
    }
} 
