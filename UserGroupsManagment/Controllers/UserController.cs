using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserGroupsManagment.Model;
using UserGroupsManagment.Model.Contractors;
using UserGroupsManagment.Model.Filters;
using UserGroupsManagment.Service.Contractors;
using UserGroupsManagment.ViewModels;

namespace UserGroupsManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        public IUserService Service{ get; }
        public IMapper Mapper { get; }

        public UserController(IUserService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int Id)
        {
            return Ok(await Service.GetOneByFilter(new UserFilter { Id = Id }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<IUser>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery]UserFilter filter)
        {
            return Ok(await Service.GetMany(filter));   
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<CreateUserViewModel, IUser>(viewModel);
                return Ok(await Service.AddOne(model));
            }
            return BadRequest();
        }
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<EditUserViewModel, IUser>(viewModel);
                return Ok(await Service.UpdateOne(model));
            }
            return BadRequest();
        }
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IUser))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Service.DeleteOne(id));
        }
    }
}
