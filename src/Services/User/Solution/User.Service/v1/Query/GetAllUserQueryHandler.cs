using System.Threading;
using System.Threading.Tasks;
using User.Data.Repository.v1;
using MicroserviceDemo.Services.User.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace User.Service.v1.Query
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, List<AppUser>>
    {
        private readonly IRepository<AppUser> _repository;

        public GetAllUserQueryHandler(IRepository<AppUser> repository)
        {
            _repository = repository;
        }

        public async Task<List<AppUser>> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll().ToListAsync();
        }
    }
}