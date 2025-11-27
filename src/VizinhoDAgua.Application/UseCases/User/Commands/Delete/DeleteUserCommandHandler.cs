using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Delete
{
    public class DeleteUserCommandHandler : DeleteCommandHandler<UserEntity, DeleteUserCommand>
    {
        public DeleteUserCommandHandler(IUserRepository repository) : base(repository)
        {
        }
    }
}
