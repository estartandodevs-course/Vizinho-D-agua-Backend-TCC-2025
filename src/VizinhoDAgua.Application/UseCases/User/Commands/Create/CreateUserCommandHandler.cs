using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, 
        CommandResponse<CreateUserCommandResponse>>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse<CreateUserCommandResponse>> Handle(
            CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate()) {
                return CommandResponse<CreateUserCommandResponse>.ValidationError(request.ValidationResult);
            }

            try
            {
                // cria um novo usuário
                var user = new Domain.Entities.User(
                    name: request.Name,
                    email: request.Email,
                    password: request.Password,
                    profileImage: request.ProfileImage
                );
                
                await _repository.AddAsync(user); // salva no banco
                var response = new CreateUserCommandResponse(user.Id); // retorna o id na resposta
                
                return CommandResponse<CreateUserCommandResponse>.Success(
                    response, statusCode: HttpStatusCode.Created); // retorna a resposta e o status
            }
            catch (Exception ex)
            {
                return CommandResponse<CreateUserCommandResponse>.CriticalError(
                    message: $"Ocorreu um erro ao criar o usuário: {ex.Message}");
            }
        }
    }
}
