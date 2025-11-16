using AutoMapper;
using VizinhoDAgua.Application.UseCases.Community.Command.Create;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.Profiles
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            CreateMap<CreateCommunityCommand, CommunityEntity>();
        }
    }
}
