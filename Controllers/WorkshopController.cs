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

        private readonly IWorkshopsLogic workshopsLogic;

        private readonly ILogger<WorkshopController> logger;

        public WorkshopController(ILogger<WorkshopController> logger, IWorkshopsLogic workshopsLogic)
        {
            this.logger = logger;
            this.workshopsLogic = workshopsLogic;
        }

        [HttpGet]
        [Route("workshopList")]
        public List<Workshop> Get()
        {
            return workshopsLogic.getAll();
        }

        [HttpPost]
        [Route("workshopList")]
        public void Post([FromBody] string workshop)
        {
            workshopsLogic.addWorkshop(workshop);
        }

        [HttpPut]
        [Route("workshopList")]
        public void Put([FromBody] Workshop workshop)
        {
            workshopsLogic.putWorkshop(workshop);
        }

        [HttpDelete]
        [Route("workshopList/{id}")]
        public void Delete([FromBody] int id)
        {
            workshopsLogic.deleteWorkshop(id);
        }

        [HttpPut]
        [Route("workshopList/{id}/Postpone")]
        public void Postpone([FromBody] int id)
        {
            workshopsLogic.postponeWorkshop(id);
        }
        [HttpPut]
        [Route("workshopList/{id}/Cancel")]
        public void Cancell([FromBody] int id)
        {
            workshopsLogic.cancellWorkshop(id);
        }
    }
}
