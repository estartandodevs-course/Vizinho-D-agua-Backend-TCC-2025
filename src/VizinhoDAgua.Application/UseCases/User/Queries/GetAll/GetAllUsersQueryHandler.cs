using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler 
        : GetAllQueryHandler<UserEntity, GetAllUsersQuery, GetAllUsersQueryResponse>
    {
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper) 
            : base(userRepository, mapper)
        {
        }
    }
}
