using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Delete;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.GeneratePresignedForUpload;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update;
using VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class EducationContentController 
        : BaseController
            <
                EducationContentEntity, 
                CreateEducationContentRequest, CreateEducationContentCommand, CreateEducationContentResponse,
                GetEducationContentByIdQuery, GetEducationContentByIdQueryResponse,
                GetAllEducationContentQuery, GetAllEducationContentQueryResponse,
                UpdateEducationContentRequest, UpdateEducationContentCommand,
                DeleteEducationContentCommand
            >
    {
        public EducationContentController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("{id}/upload")]
        public async Task<IActionResult> GeneratePresignedUrlForUpload(
            [FromRoute] Guid id,
            [FromBody] GeneratePresignedUrlDto request
        )
        {
            var command = new GeneratePresignedForUploadFileCommand(id, request.FileName);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
