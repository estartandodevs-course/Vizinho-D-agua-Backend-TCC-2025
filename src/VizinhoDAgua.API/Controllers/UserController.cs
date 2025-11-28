using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Application.UseCases.User.Commands.Delete;
using VizinhoDAgua.Application.UseCases.User.Commands.GeneratePresignedForUpload;
using VizinhoDAgua.Application.UseCases.User.Commands.Update;
using VizinhoDAgua.Application.UseCases.User.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.User.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class UserController : BaseController
        <
            UserEntity, CreateUserRequest, CreateUserCommand, CreateUserCommandResponse,
            GetUserByIdQuery, GetUserByIdQueryResponse, GetAllUsersQuery, GetAllUsersQueryResponse,
            UpdateUserRequest, UpdateUserCommand, DeleteUserCommand
        >
    {
        public UserController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }

        [HttpPost("{id}/upload")]
        public async Task<IActionResult> GeneratePresignedUrlForUpload(
            [FromRoute] Guid id,
            [FromBody] GeneratePresignedUrlDto request
        )
        {
            var command = new GeneratePresignedForUploadProfileImageCommand(id, request.FileName);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
