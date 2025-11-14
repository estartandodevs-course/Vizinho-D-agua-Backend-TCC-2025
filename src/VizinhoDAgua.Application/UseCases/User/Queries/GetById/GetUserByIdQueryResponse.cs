namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQueryResponse
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        public GetUserByIdQueryResponse(Domain.Entities.User user)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            IsAdmin = user.IsAdmin;
            ProfileImage = user.ProfileImage;
        }
    }
}