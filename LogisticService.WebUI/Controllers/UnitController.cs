﻿using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using LogisticService.Application.Feature.Units.Commands.Create;
using LogisticService.Application.Feature.Units.Commands.Delete;
using LogisticService.Application.Feature.Units.Commands.Update;
using LogisticService.Application.Feature.Units.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    public class UnitController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetServiceTypesAsync(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = true;
            return Ok(DataSourceLoader.Load(await Mediator.Send(new GetAllUnitsQuery()), loadOptions));
        }

        [HttpPost]
        public async Task<IActionResult> AddUnitAsync(CreateUnitCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUnitAsync(int id, UpdateUnitCommand command)
        {
            if (id != command.Id) return BadRequest();
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnitAsync(int id)
        {
            await Mediator.Send(new DeleteUnitCommand {Id = id});
            return NoContent();
        }
    }
}