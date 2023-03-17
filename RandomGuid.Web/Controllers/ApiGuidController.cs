using Microsoft.AspNetCore.Mvc;
using RandomGuid.Web.Models;
using RandomGuid.Web.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RandomGuid.Web
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiGuidController : ControllerBase
    {
        private readonly GuidDbContext _db;
        private readonly IGuidsService _service;

        public ApiGuidController(GuidDbContext db, IGuidsService service)
        {
            _db = db;
            _service = service;
        }

        [HttpGet]
        [Route("api/ApiGuid/Get")]
        public IEnumerable<GuidViewModel>Get()
        {
            return  _service.GetAll();
        }

      
        [HttpPut]
        [Route("api/ApiGuid/Edit")]
        public void Edit([FromBody] GuidViewModel employee)
        {
            if (ModelState.IsValid)
            {
                 _service.Update(employee);
            }
        }


    }

}

