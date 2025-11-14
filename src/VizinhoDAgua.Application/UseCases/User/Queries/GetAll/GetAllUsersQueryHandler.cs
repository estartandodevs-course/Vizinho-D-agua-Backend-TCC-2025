using System.Net;
using MediatR;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, 
        CommandResponse<GetAllUsersQueryResponse>>
    {
        private readonly IUserRepository _repository;
    
        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            _repository = repository;
        }
    
        public async Task<CommandResponse<GetAllUsersQueryResponse>> Handle(
            GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();
            return CommandResponse<GetAllUsersQueryResponse>.Success(
                new GetAllUsersQueryResponse(users), HttpStatusCode.OK);
        }
    }
}
