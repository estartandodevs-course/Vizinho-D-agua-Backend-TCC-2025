namespace VizinhoDAgua.API.Controllers.Dtos.User
{
    public record CreateUserRequest(string Name, string Email, string Password, string? ProfileImage) {}
    public record UpdateUserRequest(string Name, string? ProfileImage) {}
}