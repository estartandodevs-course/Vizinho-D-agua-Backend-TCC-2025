using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Create
{
    public class CreateUserCommandHandler 
        : CreateCommandHandler<UserEntity, CreateUserCommand, CreateUserCommandResponse>
    {
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
        }
    }
}
