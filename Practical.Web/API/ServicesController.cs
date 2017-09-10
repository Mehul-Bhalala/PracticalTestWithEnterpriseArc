using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Practical.Service;
using Practical.Web.Models;
using Practical.Data;
using Microsoft.AspNetCore.Cors;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Practical.Web.API
{
    [EnableCors("CorsPolicy")]
    [Route("services")]
    public class ServicesController : Controller
    {
        private readonly IUServicesService uServicesService;

        public ServicesController(IUServicesService uServicesService)
        {
            this.uServicesService = uServicesService;
        }
        
        // GET: api/values
        [HttpGet(Name = "GetServices")]
        [Route("list")]
        public IActionResult Get()
        {
            var services = uServicesService.GetUService().ToList();
            if (services == null)
            {
                return NotFound();
            }
            return new ObjectResult(services);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
