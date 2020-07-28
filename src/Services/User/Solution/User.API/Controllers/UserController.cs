using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MicroserviceDemo.Services.User.Service.v1.Command;
using MicroserviceDemo.Services.User.Domain.Entities;
using User.API.Model;

namespace User.API.Controllers
{
   //[Produces("application/json")]
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
        public string Get()
        {
          return "HI there";
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