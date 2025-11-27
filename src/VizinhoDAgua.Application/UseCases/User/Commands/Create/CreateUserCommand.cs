using System.Net;
using FluentValidation;
using FluentValidation.Results;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Create
{
    // DTO de entrada para criação de usuário
    public class CreateUserCommand : IRequestWithValidation<CreateUserCommandResponse>
    {
        public string Name { get; private set; } = string.Empty;
        public string Email { get; private set; } = string.Empty;
        public string Password { get; private set; }  = string.Empty;
        public bool IsAdmin { get; private set; }
        public string? ProfileImage { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!; // evita nullability warnings
        
        public CreateUserCommand() { } // permitir instâncias

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

            validations.RuleFor(command => command.Name)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O Nome é obrigatório.");
            
            validations.RuleFor(command => command.Email)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O e-mail é obrigatório.");
            
            validations.RuleFor(command => command.Password)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("A senha é obrigatória.");
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}