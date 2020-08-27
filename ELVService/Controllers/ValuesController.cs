using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


//using Microsoft.AspNetCore.Http;
//using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using ELVService.GostDatabase;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ELVService.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly gostContext _context = new gostContext();

        [HttpGet]
        [Route("GetData")]
        public dynamic getdata()
        {
           var ret = _context.Elevator.Where(x => x.Model.Equals("SEI 35/14")).ToList();
            return ret;
        }

        [HttpGet]
        [Route("getfoidbyetrid/{etrid}")]
        public dynamic GetFoIdByETRId(Guid etrid)
        {
            string guidstr= etrid.ToString().ToUpper(); 
            var ret = _context.Elevatorruntime.Where(x => x.TransportRunId.ToUpper().Equals(guidstr)).FirstOrDefault();
            return ret != null ? ret.FoiId : null;
        }

        [HttpGet]
        [Route("getelevrunbyelevatorid/{elevid}")]
        public dynamic GetElevRunByElevatorId(Guid elevid)
        {
            string a = "xcv";
            string guidstr = elevid.ToString().ToUpper();
            var ret = _context.Elevatorruntime.Where(x => x.ElevatorId.ToUpper().Equals(elevid.ToString().ToUpper())).ToList();
            return ret;
        }


        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
