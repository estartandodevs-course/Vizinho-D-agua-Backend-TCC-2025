using System.Net;
using AutoMapper;
using MediatR;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Services.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Alert.Commands.Update
{
    public class UpdateAlertCommandHandler
        : UpdateCommandHandler<AlertEntity, UpdateAlertCommand>
    {
        private readonly ICepService _cepService;
        
        public UpdateAlertCommandHandler(IAlertRepository alertRepository, IMapper mapper, ICepService cepService)
            : base(alertRepository, mapper)
        {
            _cepService = cepService;
        }

        public override async Task<CommandResponse<Unit>> Handle(UpdateAlertCommand request,
            CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError("entidade não encontrada.", HttpStatusCode.NotFound);

            // Se o CEP foi alterado, buscar os dados atualizados
            if (!string.IsNullOrEmpty(request.PostalCode) && request.PostalCode != entity.PostalCode)
            {
                var cepInfo = await _cepService.GetAddressByCepAsync(request.PostalCode, cancellationToken);
                if (cepInfo == null) return CommandResponse<Unit>.AddError("CEP inválido.");

                request.SetAddress(
                    cepInfo.Road,
                    cepInfo.Neighborhood,
                    cepInfo.City,
                    cepInfo.StateCode
                );
            }
            
            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            return CommandResponse<Unit>.Success(response, HttpStatusCode.OK);
        }
    }
}
