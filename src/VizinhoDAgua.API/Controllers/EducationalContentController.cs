using AutoMapper;
using MediatR;
using VizinhoDAgua.API.Controllers.Abstractions;
using VizinhoDAgua.Application.Dtos;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Create;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Delete;
using VizinhoDAgua.Application.UseCases.EducationContent.Commands.Update;
using VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetAll;
using VizinhoDAgua.Application.UseCases.EducationContent.Queries.GetById;
using VizinhoDAgua.Domain.Entities;

namespace VizinhoDAgua.API.Controllers
{
    public class EducationalContentController 
        : BaseController
            <
                EducationContentEntity, 
                CreateEducationalContentRequest, CreateEducationContentCommand, CreateEducationContentResponse,
                GetEducationContentByIdQuery, GetEducationContentByIdQueryResponse,
                GetAllEducationContentQuery, GetAllEducationContentQueryResponse,
                UpdateEducationalContentRequest, UpdateEducationContentCommand,
                DeleteEducationContentCommand
            >
    {
        public EducationalContentController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {
        }
    }
}
