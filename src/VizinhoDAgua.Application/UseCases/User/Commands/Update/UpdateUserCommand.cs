using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.User.Commands.Update
{
    public class UpdateUserCommand : IRequest<CommandResponse<Unit>>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? ProfileImage { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;
        
        public UpdateUserCommand(Guid id, string name, string? profileImage)
        {
            Id = id;
            Name = name;
            ProfileImage = profileImage;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateUserCommand>();
            
            // TODO: validações de entrada para atualizar usuários

            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
