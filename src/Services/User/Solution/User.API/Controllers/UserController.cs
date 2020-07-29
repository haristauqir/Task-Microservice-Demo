using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MicroserviceDemo.Services.User.Service.v1.Command;
using MicroserviceDemo.Services.User.Domain.Entities;
using User.Data.Repository.v1;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace User.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
   
   
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IRepository<AppUser> _repo;
        public UserController(IMediator mediator, IRepository<AppUser> repo)
        {
            _repo = repo;
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IEnumerable<AppUser>> Get([FromQuery]int pageSize = 10, [FromQuery]int pageIndex = 0)
        {
            var root = await _repo.GetAll().ToListAsync();


            return root;
            
        }

        [HttpPost]
        public async Task<ActionResult<AppUser>> UserSave([FromBody] AppUser model)
        {
            try
            {
                return await _mediator.Send(new CreateUserCommand
                {
                    AppUser = model
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 

    }
}