using MediatR;
using VizinhoDAgua.Application.Mediator;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetAll
{
    public class GetAllAlertsQuery : IRequest<CommandResponse<GetAllAlertsQueryResponse>>
    {
    }
}
