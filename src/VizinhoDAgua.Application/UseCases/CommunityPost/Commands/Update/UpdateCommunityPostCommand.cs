using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Command.Update
{
    public class UpdateCommunityPostCommand : IRequestWithValidationAndId<Unit>
    {
        public Guid Id { get; private set; }
        public string? Content { get; private set; }
        public List<string>? Images { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public UpdateCommunityPostCommand(Guid id, string? content, List<string>? images)
        {
            Id = id;
            Content = content;
            Images = images;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<UpdateCommunityPostCommand>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID do post é obrigatório para a atualização.");

            validations.RuleFor(c => c)
                .Must(c => !(string.IsNullOrEmpty(c.Content) && (c.Images == null || c.Images.Count == 0)))
                .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
                .WithMessage("Pelo menos um campo (Conteúdo ou Imagens) deve ser fornecido para a atualização.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
