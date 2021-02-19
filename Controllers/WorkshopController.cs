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
    [Route("workshop")]
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
        public List<Workshop> Get()
        {
            return workshopsLogic.getAll();
        }

        [HttpPost]
        public void Post([FromBody] string workshop)
        {
            workshopsLogic.addWorkshop(workshop);
        }

        [HttpPut]
        public void Put([FromBody] Workshop workshop)
        {
            workshopsLogic.putWorkshop(workshop);
        }

        [HttpDelete]
        [Route("{id}")]
        public void Delete([FromBody] int id)
        {
            workshopsLogic.deleteWorkshop(id);
        }

        [HttpPut]
        [Route("{id}/postpone")]
        public void Postpone([FromBody] int id)
        {
            workshopsLogic.postponeWorkshop(id);
        }
        [HttpPut]
        [Route("{id}/cancel")]
        public void Cancell([FromBody] int id)
        {
            workshopsLogic.cancellWorkshop(id);
        }
    }
}
