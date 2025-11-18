using AutoMapper;
using MediatR;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Application.UseCases.Community.Command.Delete;
using VizinhoDAgua.Application.UseCases.Community.Command.Update;
using VizinhoDAgua.Application.UseCases.Community.Query.GetAll;
using VizinhoDAgua.Application.UseCases.Community.Query.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class CommunityController
        : BaseController
        <
            CommunityEntity,
            CreateCommunityRequest, CreateCommunityCommand, CreateCommunityCommandResponse,
            GetCommunityByIdQuery, GetCommunityByIdQueryResponse,
            GetAllCommunitiesQuery, GetAllCommunitiesQueryResponse,
            UpdateCommunityRequest, UpdateCommunityCommand,
            DeleteCommunityCommand
        >
    {
        public CommunityController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
