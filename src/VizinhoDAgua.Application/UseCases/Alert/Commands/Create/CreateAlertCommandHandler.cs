using AutoMapper;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Services.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Create
{
    public class CreateAlertCommandHandler
        : CreateCommandHandler<AlertEntity, CreateAlertCommand, CreateAlertCommandResponse>
    {
        private readonly ICepService _cepService;

        public CreateAlertCommandHandler(IAlertRepository repository, IMapper mapper, ICepService cepService)
            : base(repository, mapper)
        {
            _cepService = cepService;
        }

        public override async Task<CommandResponse<CreateAlertCommandResponse>> Handle(
            CreateAlertCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<CreateAlertCommandResponse>.ValidationError(request.ValidationResult);

            var cepInfo = await _cepService.GetAddressByCepAsync(request.PostalCode, cancellationToken);
            if (cepInfo == null)
                return CommandResponse<CreateAlertCommandResponse>.AddError("CEP inválido.");

            request.SetAddress(
                cepInfo.Road,
                cepInfo.Neighborhood,
                cepInfo.City,
                cepInfo.StateCode
            );

            var alert = _mapper.Map<AlertEntity>(request);

            await _repository.AddAsync(alert);

            return CommandResponse<CreateAlertCommandResponse>.Success(
                _mapper.Map<CreateAlertCommandResponse>(alert.Id),
                HttpStatusCode.Created
            );
        }
    }
}
