using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById
{
    public class GetEducationContentByIdQueryHandler 
        : GetByIdQueryHandler<EducationContentEntity, GetEducationContentByIdQuery, GetEducationContentByIdQueryResponse>
    {
        public GetEducationContentByIdQueryHandler(IEducationContentRepository educationContentRepository, IMapper mapper)
            : base(educationContentRepository, mapper)
        {
        }
    }
}
