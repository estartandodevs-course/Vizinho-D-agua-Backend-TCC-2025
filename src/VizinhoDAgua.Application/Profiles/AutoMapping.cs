using AutoMapper;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Application.UseCases.Community.Command.Update;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<CreateCommunityRequest, CreateCommunityCommand>();
            CreateMap<CreateCommunityCommand, CommunityEntity>();
            CreateMap<UpdateCommunityCommand, CommunityEntity>()
                .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));
        }
    }
}
