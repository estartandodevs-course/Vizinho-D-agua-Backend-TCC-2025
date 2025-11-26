using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Community.Commands.Create;
using VizinhoDAgua.Application.UseCases.Community.Commands.Delete;
using VizinhoDAgua.Application.UseCases.Community.Commands.GeneratePresignedForUpload;
using VizinhoDAgua.Application.UseCases.Community.Commands.Update;
using VizinhoDAgua.Application.UseCases.Community.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.Community.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class CommunityController
        : BaseController
        <
            CommunityEntity,
            CreateCommunityRequest, CreateCommunityCommand, CreateCommunityCommandResponse,
            GetCommunityByIdQuery, GetCommunityByIdQueryResponse,
            GetAllCommunitiesQuery, GetAllCommunitiesQueryResponse,
            UpdateCommunityRequest, UpdateCommunityCommand,
            DeleteCommunityCommand
        >
    {
        public CommunityController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost]
        [Route("{id}/upload")]
        public async Task<IActionResult> GeneratePresignedUrlForUpload(
            [FromRoute] Guid id, 
            [FromBody] GeneratePresignedUrlDto request
        )
        {
            var command = new GeneratePresignedForUploadCommand(id, request.FileName);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
