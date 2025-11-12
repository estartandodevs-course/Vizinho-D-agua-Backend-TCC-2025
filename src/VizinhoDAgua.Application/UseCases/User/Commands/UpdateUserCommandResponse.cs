namespace VizinhoDAgua.Application.UseCases.User.Commands;

public class UpdateUserCommandResponse
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string? ProfileImage { get; private set; }
    public DateTime UpdatedAt { get; private set; }

    public UpdateUserCommandResponse(Guid id, string name, string? profileImage, DateTime updatedAt)
    {
        Id = id;
        Name = name;
        ProfileImage = profileImage;
        UpdatedAt = updatedAt;
    }
}
