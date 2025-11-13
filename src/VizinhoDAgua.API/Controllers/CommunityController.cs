using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.API.Controllers.Dtos.Community;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Application.UseCases.Community.Command.Delete;
using VizinhoDAgua.Application.UseCases.Community.Command.Update;
using VizinhoDAgua.Application.UseCases.Community.Query.GetAll;
using VizinhoDAgua.Application.UseCases.Community.Query.GetById;

namespace VizinhoDAgua.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommunityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CommunityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCommunity([FromBody] CreateCommunityRequest request)
        {
            var command = new CreateCommunityCommand(request.Title, request.Description, request.CoverImage);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommunityById(Guid id)
        {
            var query = new GetCommunityByIdQuery(id);

            var response = await _mediator.Send(query);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCommunities()
        {
            var query = new GetAllCommunitiesQuery();

            var response = await _mediator.Send(query);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommunity(Guid id, [FromBody] UpdateCommunityRequest request)
        {
            var command = new UpdateCommunityCommand(id, request.Title, request.Description, request.CoverImage);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommunity(Guid id)
        {
            var command = new DeleteCommunityCommand(id);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
