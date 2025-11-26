using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.CommunityPost.Queries.GetById
{
    public class GetCommunityPostByIdQueryHandler : GetByIdQueryHandler<CommunityPostEntity, GetCommunityPostByIdQuery, GetCommunityPostByIdQueryResponse>
    {
        public GetCommunityPostByIdQueryHandler(ICommunityPostRepository communityPostRepository, IMapper mapper) : base(communityPostRepository, mapper)
        {
        }
    }
}
