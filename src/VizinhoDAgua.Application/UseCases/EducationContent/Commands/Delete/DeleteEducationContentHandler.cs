using VizinhoDAgua.Application.Mediator.Handlers;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Commands.Delete
{
    public class DeleteEducationContentHandler 
        : DeleteCommandHandler<EducationContentEntity, DeleteEducationContentCommand>
    {
        public DeleteEducationContentHandler(IEducationContentRepository educationContentRepository)
            : base(educationContentRepository)
        {
        }
    }
}
