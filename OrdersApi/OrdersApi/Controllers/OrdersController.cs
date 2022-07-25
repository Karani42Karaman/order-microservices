using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrdersApi.Core.Model;
using OrdersApi.Core.Service;
using OrdersApi.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;


namespace OrdersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderServices _orderService;
        public OrdersController(IOrderServices orderService)
        {
            this._orderService = orderService;
        }

        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public Guid Create([FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return Guid.Empty;
            }
            bool response = RefitProxy.Instance.CustomerValidation(model.CustomerId);
            if (response)
            {
                model.CreateAt = DateTime.Now;
                _orderService.CreateOrder(model);
                return model.Id;
            }
            else
            {
                return Guid.Empty;
            }
        }

        [HttpPut("Update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool Update([FromBody] OrderModel model)
        {
            if (!ModelState.IsValid)
            {
                return false;
            }
            model.UpdateAt = DateTime.Now;
            return _orderService.UpdateOrder(model);
        }

        [HttpDelete("Delete{id}")]
        public bool Delete(Guid id)
        {
            return _orderService.RemoveOrder(id);
        }

        [HttpGet("Get{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public OrderModel Get(Guid id)
        {
            var model = _orderService.GetWithOrderAndAdressAndProduct(id);
            return model != null ? model : null;
        }

        [HttpGet("Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<OrderModel> Get()
        {
            try
            {
                return _orderService.GetAllWithOrderAndAdressAndProduct().AsEnumerable<OrderModel>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }

        [HttpPost("ChangeStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public bool ChangeStatus(Guid id, string status)
        {
            return _orderService.ChangeStatus(id, status);
        }
    }
}
