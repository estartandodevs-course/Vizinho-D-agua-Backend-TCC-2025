using AutoMapper;
using MediatR;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Alert.Commands.Create;
using VizinhoDAgua.Application.UseCases.Alert.Commands.Delete;
using VizinhoDAgua.Application.UseCases.Alert.Commands.Update;
using VizinhoDAgua.Application.UseCases.Alert.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.Alert.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class AlertController: BaseController
    <
        AlertEntity,  CreateAlertRequest, CreateAlertCommand, CreateAlertCommandResponse,
        GetAlertByIdQuery, GetAlertByIdQueryResponse, GetAllAlertsQuery, GetAllAlertsQueryResponse,
        UpdateAlertRequest, UpdateAlertCommand, DeleteAlertCommand
    >
    {
        public AlertController(IMediator mediator, IMapper mapper) 
            : base(mediator, mapper)
        {
        }
    }
}
