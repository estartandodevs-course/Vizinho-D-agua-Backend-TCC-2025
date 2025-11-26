using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.Mediator.IRequests;
using VizinhoDAgua.Domain.Entities.Abstractions;

namespace VizinhoDAgua.API.Controllers.Abstractions
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController
     <
        TEntity,
        TCreateRequest, TCreateCommand, TCreateCommandResponse,
        TGetByIdQuery, TGetByIdQueryResponse,
        TGetAllQuery, TGetAllQueryResponse,
        TUpdateRequest, TUpdateCommand,
        TDeleteCommand
     >
        : ControllerBase
        where TEntity : Entity
        where TCreateRequest : class
        where TCreateCommand : IRequestWithValidation<TCreateCommandResponse>
        where TCreateCommandResponse : class
        where TGetByIdQuery : IRequestWithValidationAndId<TGetByIdQueryResponse>
        where TGetByIdQueryResponse : class
        where TGetAllQuery : IRequest<CommandResponse<TGetAllQueryResponse>>, new()
        where TGetAllQueryResponse : class
        where TUpdateRequest : class
        where TUpdateCommand : IRequestWithValidationAndId<Unit>
        where TDeleteCommand : IRequestWithValidationAndId<Unit>
    {
        protected readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BaseController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TCreateRequest request)
        {
            var command = _mapper.Map<TCreateCommand>(request);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = _mapper.Map<TGetByIdQuery>(id);

            var response = await _mediator.Send(query);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new TGetAllQuery();

            var response = await _mediator.Send(query);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TUpdateRequest request)
        {
            var command = _mapper.Map<TUpdateCommand>((id, request));

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = _mapper.Map<TDeleteCommand>(id);

            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
