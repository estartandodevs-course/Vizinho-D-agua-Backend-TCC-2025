using AutoMapper;
using VizinhoDAgua.Application.Interfaces;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

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

        // Sobrescreve o gancho do genérico para preencher campos via ViaCEP
        protected override async Task BeforeCreateAsync(CreateAlertCommand request, CancellationToken cancellationToken)
        {
            var cepInfo = await _cepService.GetAddressByCepAsync(request.PostalCode, cancellationToken);

            if (cepInfo == null)
                throw new Exception("CEP inválido.");

            // Usa o método do comando para atualizar os campos
            request.SetAddress(
                cepInfo.Road,
                cepInfo.Neighborhood,
                cepInfo.City,
                cepInfo.StateCode
            );
        }
    }
}
