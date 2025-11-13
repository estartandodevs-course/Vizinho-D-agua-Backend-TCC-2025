namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetAllUsersQueryResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }
        
        public GetAllUsersQueryResponse(Guid id, string name, string email, bool isAdmin, string? profileImage)
        {
            Id = id;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
            ProfileImage = profileImage;
        }
    }
}
