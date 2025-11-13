namespace VizinhoDAgua.Application.UseCases.User.Queries
{
    public class GetUserByIdQueryResponse
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        public GetUserByIdQueryResponse(Guid id, string name, string email, bool isAdmin, string profileImage)
        {
            Id = id;
            Name = name;
            Email = email;
            IsAdmin = isAdmin;
            ProfileImage = profileImage;
        }
    }
}
