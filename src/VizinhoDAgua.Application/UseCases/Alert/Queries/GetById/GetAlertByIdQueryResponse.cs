using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.Alert.Queries.GetById
{
    public class GetAlertByIdQueryResponse
    {
        public AlertEntity? Alert { get; set; }

        public GetAlertByIdQueryResponse(AlertEntity? alert)
        {
            Alert = alert;
        }
    }
}
