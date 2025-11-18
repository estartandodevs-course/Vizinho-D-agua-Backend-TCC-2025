namespace VizinhoDAgua.Application.Dtos
{
    public record CreateUserRequest(string Name, string Email, string Password, string? ProfileImage) {}
    public record UpdateUserRequest(string Name, string Email, string? ProfileImage) {}
}