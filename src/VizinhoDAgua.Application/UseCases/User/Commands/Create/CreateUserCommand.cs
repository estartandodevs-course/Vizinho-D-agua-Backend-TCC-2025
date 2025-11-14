using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Create
{
    // DTO de entrada para criação de usuário
    public class CreateUserCommand : IRequest<CommandResponse<CreateUserCommandResponse>>
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!; // evita nullability warnings
        // indica ao compilador que a propriedade será inicializada antes do uso, mesmo que comece como null

        public CreateUserCommand(string name, string email, string password, bool isAdmin, string? profileImage)
        {
            Name = name;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            ProfileImage = profileImage;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<CreateUserCommand>();

            // TODO: validações de entrada para criar usuários

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}