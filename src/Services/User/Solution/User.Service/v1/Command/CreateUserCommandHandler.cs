using System.Threading;
using System.Threading.Tasks;
using User.Data.Repository.v1;
using MicroserviceDemo.Services.User.Domain.Entities;
using MediatR;


namespace MicroserviceDemo.Services.User.Service.v1.Command
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, AppUser>
    {
        private readonly IRepository<AppUser> _repository;

        public CreateUserCommandHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddAsync(request.AppUser);
        }
    }
}