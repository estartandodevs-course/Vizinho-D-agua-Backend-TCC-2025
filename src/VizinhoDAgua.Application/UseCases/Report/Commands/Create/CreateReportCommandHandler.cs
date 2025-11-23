
using MediatR;
using System.Net;
using System.Net.Mail;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.Interfaces;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Create
{
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, CommandResponse<CreateReportCommandResponse>>
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICepService _cepService;

        public CreateReportCommandHandler(
            IReportRepository reportRepository, 
            IUserRepository userRepository, 
            ICepService cepService)
        {
            _userRepository = userRepository;
            _reportRepository = reportRepository;
            _cepService = cepService;
        }

        public async Task<CommandResponse<CreateReportCommandResponse>> Handle(
            CreateReportCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<CreateReportCommandResponse>.ValidationError(request.ValidationResult);

            if (!Guid.TryParse(request.ReporterId, out Guid reporterId))
                return CommandResponse<CreateReportCommandResponse>.AddError("ID de denunciante inválido");

            if (await _userRepository.GetByIdAsync(reporterId) == null)
                return CommandResponse<CreateReportCommandResponse>.AddError("Usuário com este ID não existe");
                
            string postalCode = request.PostalCode;
            string? city = request.City;
            string? stateCode = request.StateCode;
            string? neighborhood = request.Neighborhood;
            string? road = request.Road;

            // Consulta o CEP se a cidade ou uf não forem fornecidos
            if (city == null || stateCode == null)
            {
                CepResponseDto? addressInfo = await _cepService.GetAddressByCepAsync(postalCode, cancellationToken);

                if (addressInfo == null || addressInfo.StateCode == null || addressInfo.City == null)
                    return CommandResponse<CreateReportCommandResponse>.AddError("Informe um CEP válido");
                    
                city = addressInfo.City;
                stateCode = addressInfo.StateCode;
                neighborhood = neighborhood ?? addressInfo.Neighborhood;
                road = road ?? addressInfo.Road;
            }
            
            try
            {
                var report = new ReportEntity(
                    reporterId, 
                    request.Description, 
                    postalCode, 
                    city, 
                    stateCode,
                    road, 
                    neighborhood, // informações de endereço
                    ReportStatus.InProcessing.ToString(),
                    request.ReportType
                );

                await _reportRepository.AddAsync(report);

                var response = new CreateReportCommandResponse(report.Id);

                return CommandResponse<CreateReportCommandResponse>.Success(
                    response, statusCode: HttpStatusCode.Created);


            } catch(Exception ex)
            {
                return CommandResponse<CreateReportCommandResponse>.CriticalError(ex.Message);
            }
        }
    }
}
