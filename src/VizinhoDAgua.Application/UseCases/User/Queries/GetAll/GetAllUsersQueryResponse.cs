namespace VizinhoDAgua.Application.UseCases.User.Queries.GetAll
{
    public class GetAllUsersQueryResponse
    {
        public IList<Domain.Entities.User> Users { get; set; }
        
        public GetAllUsersQueryResponse(IList<Domain.Entities.User> users)
        {
            Users = users;
        }
    }
}
