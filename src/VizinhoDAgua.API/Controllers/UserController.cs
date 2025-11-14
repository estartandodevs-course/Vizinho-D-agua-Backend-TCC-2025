using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.Application.UseCases.User.Commands.Create;
using VizinhoDAgua.Application.UseCases.User.Commands.Update;
using VizinhoDAgua.Application.UseCases.User.Commands.Delete;
using VizinhoDAgua.Application.UseCases.User.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.User.Queries.GetById;

namespace VizinhoDAgua.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator; // injeta o mediator pra mandar os comandos e queries pros handlers
        }

        // cria um novo usuário
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand request)
        {
            var command = new CreateUserCommand(
                request.Name, request.Email, request.Password, false, request.ProfileImage);

            var response = await _mediator.Send(command); // manda o comando pro handler
            return StatusCode((int)response.StatusCode, response); // retorna 201 (Created) e a resposta
        }

        // busca usuário pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id); // cria a query passando o id
            var response = await _mediator.Send(query); // manda pro handler
            return StatusCode((int)response.StatusCode, response); // retorna 200 + user
        }

        // busca todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery(); // cria a query de listar tudo
            var response = await _mediator.Send(query); // manda pro handler
            return StatusCode((int)response.StatusCode, response); // retorna a lista de users
        }

        // atualiza um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand request)
        {
            var command = new UpdateUserCommand(id, request.Name, request.ProfileImage);
            var response = await _mediator.Send(command); // manda o comando pro handler
            return StatusCode((int)response.StatusCode, response); // retorna o user atualizado
        }

        // deleta um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id); // cria o comando passando o id
            var response = await _mediator.Send(command); // manda pro handler
            return StatusCode((int)response.StatusCode, response); // 204 - deletou com sucesso, sem corpo na resposta
        }
    }
}
