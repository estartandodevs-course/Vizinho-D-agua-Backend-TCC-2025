using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Interfaces;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommandHandler 
        : IRequestHandler<CreateReportCommand, CommandResponse<CreateReportCommandResponse>>
    {
        private readonly IReportRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICepService _cepService;

        public CreateReportCommandHandler(IReportRepository repository, IMapper mapper, ICepService cepService)
        {
            _repository = repository; 
            _mapper = mapper; 
            _cepService = cepService;
        }

        public async Task<CommandResponse<CreateReportCommandResponse>> Handle(
            CreateReportCommand request, CancellationToken cancellationToken)
        {
            // Validação
            if (!request.Validate())
                return CommandResponse<CreateReportCommandResponse>.ValidationError(request.ValidationResult);

            try
            {
                // Mapeia o request ~> entidade
                var entity = _mapper.Map<ReportEntity>(request);

                // Preenche automaticamente dados do CEP
                if (!string.IsNullOrWhiteSpace(request.PostalCode))
                {
                    var cepData = await _cepService.GetAddressByCepAsync(request.PostalCode, cancellationToken);
                    if (cepData != null)
                    {
                        // Preenche apenas campos faltantes
                        entity.UpdateAddressFromCep(
                            cepData.Road,
                            cepData.Neighborhood,
                            cepData.City,
                            cepData.StateCode,
                            cepData.PostalCode
                        );
                    }
                }

                // Persiste no banco + response
                await _repository.AddAsync(entity);
                var response = new CreateReportCommandResponse(entity.Id);
                return CommandResponse<CreateReportCommandResponse>.Success(
                    response, statusCode: HttpStatusCode.Created
                );
            }
            catch (Exception ex)
            {
                return CommandResponse<CreateReportCommandResponse>.CriticalError(
                    $"Ocorreu um erro ao criar a entidade: {ex.Message}"
                );
            }
        }
    }
}
