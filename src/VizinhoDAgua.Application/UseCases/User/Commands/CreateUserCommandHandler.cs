using MediatR;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateUserCommandResponse> 
            Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // cria um novo usuário
            var user = new Domain.Entities.User(
                command.Name,
                command.Email,
                command.Password,
                command.ProfileImage
            );

            // salva no banco
            await _repository.AddAsync(user);
            // retorna o id na resposta
            return new CreateUserCommandResponse(user.Id);
        }
    }
}
