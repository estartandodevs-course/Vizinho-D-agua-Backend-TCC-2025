using MediatR;

namespace VizinhoDAgua.Application.UseCases.User.Commands
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string? ProfileImage { get; private set; }
        
        public UpdateUserCommand(string name, string profileImage)
        {
            Name = name;
            ProfileImage = profileImage;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }
    }
}
