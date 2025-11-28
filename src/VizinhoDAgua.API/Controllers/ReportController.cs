using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Report.Commands.Create;
using VizinhoDAgua.Application.UseCases.Report.Commands.Delete;
using VizinhoDAgua.Application.UseCases.Report.Commands.GeneratePresignedForUpload;
using VizinhoDAgua.Application.UseCases.Report.Commands.Update;
using VizinhoDAgua.Application.UseCases.Report.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.Report.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class ReportController: BaseController
        <
            ReportEntity,  CreateReportRequest, CreateReportCommand, CreateReportCommandResponse,
            GetReportByIdQuery, GetReportByIdQueryResponse, GetAllReportsQuery, GetAllReportsQueryResponse,
            UpdateReportRequest, UpdateReportCommand, DeleteReportCommand
        >
    {
        public ReportController(IMediator mediator, IMapper mapper) 
            : base(mediator, mapper)
        {
        }

        [HttpPost("{id}/upload")]
        public async Task<IActionResult> GeneratePresignedUrlForUpload(
            [FromRoute] Guid id,
            [FromBody] GeneratePresignedUrlDto request
        )
        {
            var command = new GeneratePresignedForUploadAttachmentCommand(id, request.FileName);

            var response = await _mediator.Send(command);
            
            return StatusCode((int)response.StatusCode, response);
        }
    }
}
