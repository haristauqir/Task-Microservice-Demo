using MediatR;
using MicroserviceDemo.Services.User.Domain.Entities;
using System.Collections.Generic;

namespace User.Service.v1.Query
{
    public class GetAllUserQuery : IRequest<List<AppUser>>
    {   
    }
}