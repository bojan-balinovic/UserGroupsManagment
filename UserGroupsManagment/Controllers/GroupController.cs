using AutoMapper;
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

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GroupFilter filter)
        {
            if (filter.CurrentPage > 0)
            {
                return Ok(await Service.GetMany(filter));
            }
            else
            {
                return Ok(await Service.GetAll());
            }

        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateGroupViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = Mapper.Map<CreateGroupViewModel, IGroup>(viewModel);
                return Ok(await Service.AddOne(model));
            }
            return BadRequest();
        }
        [HttpPut]
        public async Task<IActionResult> Edit(Group model)
        {
            if (ModelState.IsValid)
            {
                return Ok(await Service.UpdateOne(model));
            }
            return BadRequest();
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Service.DeleteOne(id));
        }
    }
}
