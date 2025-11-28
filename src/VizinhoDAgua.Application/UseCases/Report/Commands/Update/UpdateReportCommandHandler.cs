using AutoMapper;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;
using VizinhoDAgua.Infrastructure.Services.Interfaces;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.Update
{
    public class UpdateReportCommandHandler : UpdateCommandHandler<ReportEntity, UpdateReportCommand>
    {
        private readonly ICepService _cepService;

        public UpdateReportCommandHandler(IReportRepository reportRepository, IMapper mapper, ICepService cepService)
            : base(reportRepository, mapper)
        {
            _cepService = cepService;
        }

        public override async Task<CommandResponse<Unit>> Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<Unit>.ValidationError(request.ValidationResult);

            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                return CommandResponse<Unit>.AddError(message: "entidade não encontrada.", statusCode: HttpStatusCode.NotFound);

            if(string.IsNullOrEmpty(request.PostalCode))
                request.AddPostalCodeInRequest(entity.PostalCode);

            var cepData = await _cepService.GetAddressByCepAsync(request.PostalCode ?? string.Empty, cancellationToken);

            if (cepData?.StateCode == null || cepData.City == null)
            {
                return CommandResponse<Unit>.AddError("CEP inválido.");
            }

            request.AddAddressInRequest(
                request.City ?? cepData.City,
                request.StateCode ?? cepData.StateCode,
                request.Road ?? cepData.Road,
                request.Neighborhood ?? cepData.Neighborhood
            );

            _mapper.Map(request, entity);
            await _repository.UpdateAsync(entity);

            return CommandResponse<Unit>.Success(response, HttpStatusCode.OK);
        }
    }
}
