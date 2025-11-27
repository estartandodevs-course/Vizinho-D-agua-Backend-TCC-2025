using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Update
{
    public class UpdateUserCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string? ProfileImage { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public UpdateUserCommand(Guid id, string name, string email, string password, string? profileImage)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
            ProfileImage = profileImage;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateUserCommand>();

            validations.RuleFor(command => command.Id)
                .NotEmpty()
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("O ID do usuário é obrigatório para a atualização.");

            validations.RuleFor(command => command)
                .Must(command => !
                    (
                        string.IsNullOrEmpty(command.Name) &&
                        string.IsNullOrEmpty(command.Email) && 
                        string.IsNullOrEmpty(command.Password) &&
                        string.IsNullOrEmpty(command.ProfileImage)
                    )
                )
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("Pelo menos um campo deve ser fornecido para a atualização.");

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
