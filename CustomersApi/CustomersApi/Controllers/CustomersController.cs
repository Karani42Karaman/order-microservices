using CustomersApi.Core.Model;
using CustomersApi.Core.Repositories;
using CustomersApi.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CustomersApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;  
        public CustomersController(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        // GET: api/<CustomersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {

            var a =_customerService.GetAllCustomerAsync().Result;
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomersController>
        [HttpPost]
        public void Post([FromBody] CustomerModel model)
        {
           
                _customerService.CreateCustomerAsync(model);
            
            var a =model.Id;
            

        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
