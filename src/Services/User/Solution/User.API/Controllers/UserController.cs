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
using User.Service.v1.Query;

namespace User.API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
   
   
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<List<AppUser>>> Get()
        {
            try
            {
                return await _mediator.Send(new GetAllUserQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }       
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