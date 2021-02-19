using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using TrueWebAPI.BusinessLogic;

namespace TrueWebAPI.Controllers
{
    [ApiController]
    [Route("workshopList")]
    public class WorkshopController : ControllerBase
    {
        WorkshopsLogic wl = new WorkshopsLogic();

        private readonly ILogger<WorkshopController> _logger;

        public WorkshopController(ILogger<WorkshopController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("workshopList")]
        public List<Workshop> Get()
        {
            return wl.getAll();
        }

        [HttpPost]
        [Route("workshopList")]
        public void Post([FromBody] string workshop)
        {
            wl.addWorkshop(workshop);
        }

        [HttpPut]
        [Route("workshopList")]
        public void Put([FromBody] Workshop workshop)
        {
            wl.putWorkshop(workshop);
        }

        [HttpDelete]
        [Route("workshopList/{id}")]
        public void Delete([FromBody] int id)
        {
            wl.deleteWorkshop(id);
        }

        [HttpPut]
        [Route("workshopList/{id}/Postpone")]
        public void Postpone([FromBody] int id)
        {
            wl.postponeWorkshop(id);
        }
        [HttpPut]
        [Route("workshopList/{id}/Cancel")]
        public void Cancell([FromBody] int id)
        {
            wl.cancellWorkshop(id);
        }
    }
}
