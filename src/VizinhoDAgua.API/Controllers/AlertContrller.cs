using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Alert.Commands.Create;
using VizinhoDAgua.Application.UseCases.Alert.Commands.UpdateStatus;
using VizinhoDAgua.Application.UseCases.Alert.Queries.GetAll;

namespace VizinhoDAgua.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AlertController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // POST /api/alert
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAlertRequest request)
        {
            var command = _mapper.Map<CreateAlertCommand>(request);
            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }

        // GET /api/alert
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllAlertsQuery());
            return StatusCode((int)response.StatusCode, response);
        }

        // PUT /api/alert/{id}/status
        [HttpPut("{id}/status")]
        public async Task<IActionResult> UpdateStatus(Guid id, [FromBody] UpdateAlertStatusRequest request)
        {
            var command = _mapper.Map<UpdateAlertStatusCommand>((id, request));
            var response = await _mediator.Send(command);

            return StatusCode((int)response.StatusCode, response);
        }
    }
}
