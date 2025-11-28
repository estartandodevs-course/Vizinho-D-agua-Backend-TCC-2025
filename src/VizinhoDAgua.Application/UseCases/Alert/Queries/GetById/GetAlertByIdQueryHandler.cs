using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetById
{
    public class GetAlertByIdQueryHandler
        : GetByIdQueryHandler<AlertEntity, GetAlertByIdQuery, GetAlertByIdQueryResponse>
    {
        public GetAlertByIdQueryHandler(IAlertRepository alertRepository, IMapper mapper)
            : base(alertRepository, mapper)
        {
        }
    }
}
