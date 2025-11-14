using FluentValidation;
using FluentValidation.Results;
using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.User.Queries.GetById
{
    public class GetUserByIdQuery : IRequest<CommandResponse<GetUserByIdQueryResponse>>
    {
        public Guid Id { get; private set; }

        public ValidationResult ValidationResult { get; private set; } = null!;

        public GetUserByIdQuery(Guid id)
        {
            Id = id;
        }

        public bool Validade()
        {
            var validations = new InlineValidator<GetUserByIdQuery>();
            
            // TODO: validações de entrada
            
            ValidationResult = validations.Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
