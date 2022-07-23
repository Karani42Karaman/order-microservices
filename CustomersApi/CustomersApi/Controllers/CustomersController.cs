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


        [HttpPost]
        public Guid Create([FromBody] CustomerModel model)
        {
            _customerService.CreateCustomerAsync(model);
            return model.Id;
        }

        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public bool Update([FromBody] CustomerModel model)
        {
            _customerService.UpdateCustomerAsync(model);
            return false;
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public bool Delete(Guid id)
        {
            return _customerService.RemoveCustomer(id);
        }

        [HttpGet]
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

        [HttpGet("{id}")]
        public CustomerModel Get(Guid id)
        {
            return _customerService.GetWithCutomerAndAdress(id);
        }
    }
}
