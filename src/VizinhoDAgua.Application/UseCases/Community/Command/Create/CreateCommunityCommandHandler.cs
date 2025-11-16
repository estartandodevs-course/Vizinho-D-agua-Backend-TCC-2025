using MediatR;
using System.Net;
using VizinhoDAgua.Application.Mediator;
using VizinhoDAgua.Domain.Entities;
using VizinhoDAgua.Domain.Repositories;

namespace VizinhoDAgua.Application.UseCases.Community.Command.Create
{
    public class CreateCommunityCommandHandler : IRequestHandler<CreateCommunityCommand, CommandResponse<CreateCommunityCommandResponse>>
    {
        private readonly ICommunityRepository _communityRepository;

        public CreateCommunityCommandHandler(ICommunityRepository communityRepository)
        {
            _communityRepository = communityRepository;
        }

        public async Task<CommandResponse<CreateCommunityCommandResponse>> Handle(CreateCommunityCommand request, CancellationToken cancellationToken)
        {
            if (!request.Validate())
                return CommandResponse<CreateCommunityCommandResponse>.ValidationError(request.ValidationResult);

            try
            {
                var community = new CommunityEntity(
                    title: request.Title,
                    description: request.Description,
                    coverImage: request.CoverImage
                );

                await _communityRepository.AddAsync(community);

                var response = new CreateCommunityCommandResponse(community.Id);

                return CommandResponse<CreateCommunityCommandResponse>.Success(response, statusCode: HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return CommandResponse<CreateCommunityCommandResponse>.CriticalError(message: $"Ocorreu um erro ao criar a comunidade: {ex.Message}");
            }
        }
    }
}
