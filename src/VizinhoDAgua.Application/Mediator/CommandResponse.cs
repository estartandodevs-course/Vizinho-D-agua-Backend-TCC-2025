using FluentValidation.Results;
using System.Net;

namespace VizinhoDAgua.Application.Mediator
{
    public class CommandResponse<T>
    {
        public HttpStatusCode StatusCode { get; private set; }
        public string Message { get; private set; }
        public T Data { get; private set; } = default!;

        public CommandResponse(HttpStatusCode statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }
        public CommandResponse(HttpStatusCode statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public static CommandResponse<T> Success(T data, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(statusCode, string.Empty, data);

        public static CommandResponse<T> Success(string message, HttpStatusCode statusCode = HttpStatusCode.OK)
            => new(statusCode, message);

        public static CommandResponse<T> AddError(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
            => new(statusCode, message);

        public static CommandResponse<T> ValidationError(string message, string statusCode)
        {
            if (int.TryParse(statusCode, out var statusCodeInt) &&
                Enum.IsDefined(typeof(HttpStatusCode), statusCodeInt))
            {
                return new((HttpStatusCode)statusCodeInt, message);
            }

            return new(HttpStatusCode.InternalServerError, "Código de status inválido fornecido na resposta de erro de validação.");
        }

        public static CommandResponse<T> ValidationError(ValidationResult validationResult)
        {
            var errors = validationResult.Errors
                .Select(f => new { message = f.ErrorMessage, statusCode = f.ErrorCode })
                .ToList();

            if (int.TryParse(errors.First().statusCode, out var statusCodeInt) &&
                Enum.IsDefined(typeof(HttpStatusCode), statusCodeInt))
            {
                return new((HttpStatusCode)statusCodeInt, errors.First().message);
            }

            return new(HttpStatusCode.InternalServerError, "Código de status inválido fornecido na resposta de erro de validação.");
        }

        public static CommandResponse<T> CriticalError(string message)
            => new(HttpStatusCode.InternalServerError, message);

    }
}