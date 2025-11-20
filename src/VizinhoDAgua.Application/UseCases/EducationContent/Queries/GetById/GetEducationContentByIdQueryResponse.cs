using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById
{
    public class GetEducationContentByIdQueryResponse
    {
        public EducationContentEntity EducationContent { get; set; }

        public GetEducationContentByIdQueryResponse(EducationContentEntity educationContent)
        {
            EducationContent = educationContent;
        }
    }
}
