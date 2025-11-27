using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetAll
{
    public class GetAllAlertsQueryHandler 
        : GetAllQueryHandler<AlertEntity, GetAllAlertsQuery, GetAllAlertsQueryResponse>
    {
        public GetAllAlertsQueryHandler(IAlertRepository repository, IMapper mapper)
            : base(repository, mapper) {}
    }
}
