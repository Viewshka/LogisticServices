using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using LogisticService.Application.Common;
using LogisticService.Application.Feature.ServiceType.Queries.GetServiceTypes;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    public class ServiceTypeController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> GetServiceTypesAsync(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = true;
            return Ok(DataSourceLoader.Load(await Mediator.Send(new GetServiceTypesQuery()), loadOptions));
        }
    }
}