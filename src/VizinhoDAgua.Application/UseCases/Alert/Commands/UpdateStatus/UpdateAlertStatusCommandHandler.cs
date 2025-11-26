using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus
{
    public class UpdateAlertStatusCommandHandler
        : UpdateCommandHandler<AlertEntity, UpdateAlertStatusCommand>
    {
        public UpdateAlertStatusCommandHandler(IAlertRepository repository, IMapper mapper)
            : base(repository, mapper) { }

        protected override void ApplyUpdate(UpdateAlertStatusCommand request, AlertEntity entity)
        {
            entity.UpdateStatus(request.NewStatus);
        }
    }
}
