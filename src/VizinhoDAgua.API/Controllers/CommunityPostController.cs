using AutoMapper;
using MediatR;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.CommunityPost.Command.Create;
using VizinhoDAgua.Application.UseCases.CommunityPost.Command.Delete;
using VizinhoDAgua.Application.UseCases.CommunityPost.Command.Update;
using VizinhoDAgua.Application.UseCases.CommunityPost.Query.GetAll;
using VizinhoDAgua.Application.UseCases.CommunityPost.Query.GetById;
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
