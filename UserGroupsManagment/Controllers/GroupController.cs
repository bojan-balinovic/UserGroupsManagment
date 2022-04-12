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

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IGroup))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOne(int Id)
        {
            return Ok(await Service.GetOneByFilter(new GroupFilter { Id = Id }));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationList<IGroup>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromQuery] GroupFilter filter)
        {
            return Ok(await Service.GetMany(filter));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IGroup))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Post(CreateGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                IGroup model = Mapper.Map<CreateGroupViewModel, IGroup>(viewModel);
                return Ok(await Service.AddOne(model));
            }
            return BadRequest();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IGroup))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Edit(GroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<GroupViewModel, IGroup>(viewModel);
                return Ok(await Service.UpdateOne(model));
            }
            return BadRequest();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IGroup))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Service.DeleteOne(id));
        }
    }
}
