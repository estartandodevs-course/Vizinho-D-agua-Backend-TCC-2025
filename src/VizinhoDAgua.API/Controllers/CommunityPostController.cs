using AutoMapper;
using MediatR;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Create;
using VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Delete;
using VizinhoDAgua.Application.UseCases.CommunityPost.Commands.Update;
using VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class CommunityPostController
        : BaseController
        <
            CommunityPostEntity,
            CreateCommunityPostRequest, CreateCommunityPostCommand, CreateCommunityPostCommandResponse,
            GetCommunityPostByIdQuery, GetCommunityPostByIdQueryResponse,
            GetAllCommunitiesPostQuery, GetAllCommunitiesPostQueryResponse,
            UpdateCommunityPostRequest, UpdateCommunityPostCommand,
            DeleteCommunityPostCommand
        >
    {
        public CommunityPostController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
