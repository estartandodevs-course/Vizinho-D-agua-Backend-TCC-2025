using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryResponse
    {
        public IList<UserEntity> Users { get; }
        
        public GetAllUsersQueryResponse(IList<UserEntity> users)
        {
            Users = users;
        }
    }
}
