using FluentValidation;
using FluentValidation.Results;
using System.Net;
using VizinhoDAgua.Application.Mediator.IRequests;

namespace VizinhoDAgua.Application.UseCases.Report.Commands.GeneratePresignedForUpload
{
    public class GeneratePresignedForUploadAttachmentCommand : IRequestWithValidationAndId<GeneratePresignedForUploadAttachmentCommandResponse>
    {
        public Guid Id { get; private set; }
        public string FileName { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public GeneratePresignedForUploadAttachmentCommand(Guid id, string fileName)
        {
            Id = id;
            FileName = fileName.Trim();
        }

        public bool Validate()
        {
            var validations = new InlineValidator<GeneratePresignedForUploadAttachmentCommand>();

            validations.RuleFor(g => g.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID da comunidade é obrigatório.");

            validations.RuleFor(g => g.FileName)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O nome do arquivo é obrigatório para gerar o link de upload.");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
