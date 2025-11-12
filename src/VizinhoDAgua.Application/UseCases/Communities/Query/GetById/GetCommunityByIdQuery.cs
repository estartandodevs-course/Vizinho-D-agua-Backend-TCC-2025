using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Application.UseCases.Communities.Query.GetAll;

namespace VizinhoDAgua.Application.UseCases.Communities.Query.GetById
{
    public class GetCommunityByIdQuery : IRequest<CommandResponse<GetCommunityByIdQueryResponse>>
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; }

        public GetCommunityByIdQuery(Guid id)
        {
            Id = id;
        }

        public bool Validate()
        {
            var validations = new InlineValidator<GetCommunityByIdQuery>();

            validations.RuleFor(c => c.Id)
            .NotEmpty()
            .WithErrorCode(((int)HttpStatusCode.BadRequest).ToString())
            .WithMessage("O ID da comunidade é obrigatório");

            ValidationResult = validations.Validate(this);

            return ValidationResult.IsValid;
        }
    }
}
