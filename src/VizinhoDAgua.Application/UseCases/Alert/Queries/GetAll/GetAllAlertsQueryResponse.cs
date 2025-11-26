using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetAll
{
    public class GetAllAlertsQueryResponse
    {
        public IList<AlertEntity> Alerts { get; set; }

        public GetAllAlertsQueryResponse(IList<AlertEntity> alerts)
        {
            Alerts = alerts;
        }
    }
}
