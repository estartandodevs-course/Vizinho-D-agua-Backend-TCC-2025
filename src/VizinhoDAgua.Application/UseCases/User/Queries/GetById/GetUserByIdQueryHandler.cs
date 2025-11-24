using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryHandler 
        : GetByIdQueryHandler<UserEntity, GetUserByIdQuery, GetUserByIdQueryResponse>
    {
        public GetUserByIdQueryHandler(IUserRepository userRepository, IMapper mapper) 
            : base(userRepository, mapper)
        {
        }
    }
}
