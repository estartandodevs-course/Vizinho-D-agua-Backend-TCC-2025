using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll
{
    public class GetAllEducationContentQueryResponse
    {
        public IList<EducationContentEntity> EducationContents { get; set; }
        
        public GetAllEducationContentQueryResponse(IList<EducationContentEntity> educationContents)
        {
            EducationContents = educationContents;
        }
    }
}
