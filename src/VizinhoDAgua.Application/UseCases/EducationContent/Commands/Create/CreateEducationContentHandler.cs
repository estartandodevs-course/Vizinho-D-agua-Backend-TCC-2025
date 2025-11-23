using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create
{
    public class CreateEducationContentHandler 
        : CreateCommandHandler<EducationContentEntity, CreateEducationContentCommand, CreateEducationContentResponse> 
    {
        public CreateEducationContentHandler(IEducationContentRepository educationContentRepository, IMapper mapper)
            : base(educationContentRepository, mapper)
        {
        }
    }
}
