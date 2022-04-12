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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int id)
        {
            var model = await Service.GetOneByFilter(new UserFilter { Id = id });
            var viewModel = Mapper.Map<IUser, UserViewModel>(model);
            return Ok(viewModel);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<UserViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery]UserFilter filter)
        {
            var paginationList= await Service.GetMany(filter);
            var viewModels = paginationList.GetMapped<UserViewModel>();
            return Ok(viewModels);   
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<CreateUserViewModel, IUser>(viewModel);
                model = await Service.AddOne(model);
                var userViewModel = Mapper.Map<IUser, UserViewModel>(model);
                return Ok(userViewModel);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EditUserViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(EditUserViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<EditUserViewModel, IUser>(viewModel);
                model = await Service.UpdateOne(model);
                var userViewModel = Mapper.Map<IUser, UserViewModel>(model);
                return Ok(userViewModel);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.DeleteOne(id);
            if (model == null) return NotFound();
            var viewModel = Mapper.Map<IUser, UserViewModel>(model);
            return Ok(viewModel);
        }
    }
}
