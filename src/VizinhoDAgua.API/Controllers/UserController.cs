using MediatR;
using Microsoft.AspNetCore.Mvc;
using VizinhoDAgua.Application.UseCases.User.Commands;
using VizinhoDAgua.Application.UseCases.User.Queries;

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
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await _mediator.Send(command); // manda o comando pro handler
            // retorna 201 (Created) e o objeto criado
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // busca usuário pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var query = new GetUserByIdQuery(id); // cria a query passando o id
            var user = await _mediator.Send(query); // manda pro handler

            if (user == null)
                return NotFound("Usuário não encontrado.");

            return Ok(user); // retorna 200 + user
        }

        // busca todos os usuários
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetAllUsersQuery(); // cria a query de listar tudo
            var users = await _mediator.Send(query); // manda pro handler
            return Ok(users); // retorna a lista de users
        }

        // atualiza um usuário
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.SetId(id); // injeta o id da URL no comando

            var result = await _mediator.Send(command); // manda o comando pro handler
            return Ok(result); // retorna o user atualizado
        }

        // deleta um usuário
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand(id); // cria o comando passando o id
            var result = await _mediator.Send(command); // manda pro handler

            if (!result) return NotFound("Usuário não encontrado.");
            return NoContent(); // 204 - deletou com sucesso, sem corpo na resposta
        }
    }
}
