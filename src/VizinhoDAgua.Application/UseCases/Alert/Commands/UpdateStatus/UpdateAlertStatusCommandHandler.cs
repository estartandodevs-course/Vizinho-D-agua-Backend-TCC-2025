using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Entities.Enum;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus
{
    public class UpdateAlertStatusCommandHandler
        : UpdateCommandHandlerWithReturn<AlertEntity, UpdateAlertStatusCommand, AlertStatus>
    {
        protected override AlertStatus response { get; set; } = AlertStatus.UnderVerification;

        public UpdateAlertStatusCommandHandler(IAlertRepository repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
