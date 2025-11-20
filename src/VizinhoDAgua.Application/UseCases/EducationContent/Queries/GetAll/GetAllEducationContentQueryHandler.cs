using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll
{
    public class GetAllEducationContentQueryHandler 
        : GetAllQueryHandler<EducationContentEntity, GetAllEducationContentQuery, GetAllEducationContentQueryResponse>
    {
        public GetAllEducationContentQueryHandler (IEducationContentRepository educationContentRepository, IMapper mapper)
            : base(educationContentRepository, mapper)
        {
        }
    }
}
