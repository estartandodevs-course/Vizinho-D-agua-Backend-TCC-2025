using AutoMapper;
using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update
{
    public class UpdateEducationContentHandler 
        : UpdateCommandHandler<EducationContentEntity, UpdateEducationContentCommand>
    {
        public UpdateEducationContentHandler(IEducationContentRepository educationContentRepository, IMapper mapper)
            : base(educationContentRepository, mapper)
        {
        }
    }
}
