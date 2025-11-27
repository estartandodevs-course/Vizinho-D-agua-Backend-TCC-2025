using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Update
{
    public class UpdateUserCommandHandler : UpdateCommandHandler<UserEntity, UpdateUserCommand>
    {
        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper) 
            : base(userRepository, mapper)
        {
        }
    }
}
