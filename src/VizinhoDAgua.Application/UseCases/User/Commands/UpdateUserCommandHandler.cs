using MediatR;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(command.Id);
            if (user == null) throw new Exception("Usuário não encontrado.");

            user.Update(command.Name, command.ProfileImage);
            
            await _repository.UpdateAsync(user);
            return new UpdateUserCommandResponse(
                user.Id,
                user.Name,
                user.ProfileImage,
                DateTime.UtcNow
            );
        }
    }
}
