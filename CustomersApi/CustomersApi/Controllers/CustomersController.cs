using CustomersApi.Core.Model;
using CustomersApi.Core.Service;
using Microsoft.AspNetCore.Http;
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

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Guid Create([FromBody] CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return Guid.Empty;
            }
            model.CreateAt = DateTime.Now;
            _customerService.CreateCustomerAsync(model);
            return model.Id;
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update([FromBody] CustomerModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            model.UpdateAt = DateTime.Now;
            return _customerService.UpdateCustomerAsync(model);
        }

        [HttpDelete("Delete{id}")]
        public bool Delete(Guid id)
        {
            return _customerService.RemoveCustomer(id);
        }

        [HttpGet("Get{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public CustomerModel Get(Guid id)
        {
            var model = _customerService.GetWithCutomerAndAdress(id);
            return model != null ? model: null;
        }
        
        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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

        [HttpGet("Validation{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Task<bool> Validation(Guid id)
        {
            return Task.FromResult<bool>(_customerService.Validate(id));
        }
    }
}
