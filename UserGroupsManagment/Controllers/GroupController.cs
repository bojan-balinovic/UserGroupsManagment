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
    public class GroupController : ControllerBase
    {
        public IGroupService Service { get; }
        public IMapper Mapper { get; }

        public GroupController(IGroupService service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int id)
        {
            var model = await Service.GetOneByFilter(new GroupFilter { Id = id });
            var viewModel = Mapper.Map<IGroup, GroupViewModel>(model);
            return Ok(viewModel);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<GroupViewModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GroupFilter filter)
        {
            var paginationList = await Service.GetMany(filter);
            var viewModels = paginationList.GetMapped<GroupViewModel>();
            return Ok(viewModels);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IGroup model = Mapper.Map<CreateGroupViewModel, IGroup>(viewModel);
                model=await Service.AddOne(model);
                var groupViewModel = Mapper.Map<IGroup, GroupViewModel>(model);
                return Ok(groupViewModel);
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(EditGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<EditGroupViewModel, IGroup>(viewModel);
                model = await Service.UpdateOne(model);
                var groupViewModel = Mapper.Map<IGroup, GroupViewModel>(model);
                return Ok(groupViewModel);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupViewModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await Service.DeleteOne(id);
            if (model == null) return NotFound();
            var viewModel = Mapper.Map<IGroup, GroupViewModel>(model);
            return Ok(viewModel);
        }
    }
}
