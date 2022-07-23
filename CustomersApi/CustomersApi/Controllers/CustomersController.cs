using CustomersApi.Core.Model;
using CustomersApi.Core.Repositories;
using CustomersApi.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

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

        [HttpPost("Create")]
        public Guid Create([FromBody] CustomerModel model)
        {

            _customerService.CreateCustomerAsync(model);
            return model.Id;
        }

        [HttpPut("Update")]
        public bool Update([FromBody] CustomerModel model)
        {            
            return _customerService.UpdateCustomerAsync(model);
        }

        [HttpDelete("Delete{id}")]
        public bool Delete(Guid id)
        {
            return _customerService.RemoveCustomer(id);
        }

        [HttpGet("Get{id}")]
        public ActionResult<CustomerModel> Get(Guid id)
        {
            var model = _customerService.GetWithCutomerAndAdress(id);
            return model != null ? model: null;
        }
        
        [HttpGet("Get")]
        public IEnumerable<CustomerModel> Get()
        {
            try
            {
                return _customerService.GetAllWithCutomerAndAdress().AsEnumerable<CustomerModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpGet("Validation")]
        public bool Validation(Guid id)
        {
            return _customerService.Validate(id);
        }
    }
}
