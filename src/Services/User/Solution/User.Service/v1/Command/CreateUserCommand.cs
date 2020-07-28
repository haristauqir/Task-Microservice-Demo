using MediatR;
using MicroserviceDemo.Services.User.Domain.Entities;
namespace MicroserviceDemo.Services.User.Service.v1.Command
{
    public class CreateUserCommand : IRequest<AppUser>
    {
        public AppUser AppUser { get; set; }
    }
}