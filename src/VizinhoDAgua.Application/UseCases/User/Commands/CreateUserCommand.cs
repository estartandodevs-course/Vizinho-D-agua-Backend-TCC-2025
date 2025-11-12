using MediatR;

namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    // DTO de entrada para criação de usuário
    public class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        public CreateUserCommand(string name, string email, string password, bool isAdmin, string? profileImage)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            ProfileImage = profileImage;
        }
    }
}