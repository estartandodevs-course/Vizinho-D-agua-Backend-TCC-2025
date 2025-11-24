using Amazon.Runtime.Internal;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using OpenTelemetry.Trace;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Report.Commands.Create;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController: ControllerBase
    {
        private readonly IMediator _mediator;

        public ReportController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateReportRequest request)
        {
            var command = new CreateReportCommand(
                request.Description,
                request.ReportType,
                request.ReporterId,
                request.PostalCode,
                request.StateCode,
                request.City,
                request.Neighborhood,
                request.Road,
                request.Lat,
                request.Lon
            );

            var response = await _mediator.Send(command); // manda o comando pro handler
            return StatusCode((int)response.StatusCode, response); // retorna 201 (Created) e a resposta
        }
    }
}
