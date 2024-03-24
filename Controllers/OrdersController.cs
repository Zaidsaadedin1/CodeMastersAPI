using CodeMasters.Dtos.OrdersDtos;
using CodeMasters.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CodeMasters.Controllers
{
  
    public class OrdersController : ControllerBase
    {
        private readonly IOrder _orderService;

        public OrdersController(IOrder orderService)
        {
            _orderService = orderService;
        }

        [HttpPost("/CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto createOrderDto)
        {
            try
            {
                var orderId = await _orderService.CreateOrder(createOrderDto);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);    
            }
        }

        [HttpPut("/UpdateOrder")]
        public async Task<IActionResult> UpdateOrder([FromQuery] int id, [FromBody]UpdateOrderDto updateOrderDto)
        {
            try
            {
                /*
                if ()
                {
                    return BadRequest("Invalid request");
                }
                */
                await _orderService.UpdateOrder(updateOrderDto,id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/DeleteOrder")]
        public async Task<IActionResult> DeleteOrder([FromQuery]int id)
        {
            try
            {
                var orderId = await _orderService.DeleteOrder(id);
                return Ok(orderId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("/GetOrderById")]
        public async Task<IActionResult> GetOrderById([FromQuery] int id)
        {
            try
            {
                var order = await _orderService.GetOrderById(id);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet("/GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
