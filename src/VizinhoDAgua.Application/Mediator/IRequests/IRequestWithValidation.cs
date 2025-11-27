using FluentValidation.Results;
using MediatR;

namespace VizinhoDAgua.Application.Mediator.IRequests
{
    public interface IRequestWithValidation<ICommandResponse> : IRequest<CommandResponse<ICommandResponse>>
    {
        ValidationResult ValidationResult { get; }

        bool Validate();
    }
}
