using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Ingredients.Queries;
using FinalBakery.Application.Features.OrderItems.Commands;
using FinalBakery.Application.Features.OrderItems.Queries;
using FinalBakery.Application.Features.Orders.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createOrderItem")]
        public async Task<IActionResult> CreateOrderItem([FromQuery] int orderId, [FromQuery] int breadId, [FromQuery] int orderItemPrice, [FromQuery] int orderItemQuantity)
        {
            try
            {
                OrderItemDTO orderItemDTO = new OrderItemDTO();
                orderItemDTO.BreadId = breadId;
                orderItemDTO.OrderId = orderId;
                orderItemDTO.OrderItem_Cost = orderItemPrice;
                orderItemDTO.OrderItem_Quantity = orderItemQuantity;
                orderItemDTO.Audit = new Domain.Common.AuditInfo()
                {
                    CreatedBy = "Isra",
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                };

                CreateOrderItemCommand createOrderItemCommand = new CreateOrderItemCommand()
                {
                    OrderItemDto = orderItemDTO,
                };

                CreateComandResponse<OrderItem> response = await _mediator.Send(createOrderItemCommand);

                return Ok(response);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "Internal server error", details = ex.Message });
            }
        }

        [HttpGet("getOrderItemsByOrderId")]
        public async Task<IActionResult> GetOrderItemsByOrderId([FromQuery] int orderId)
        {
            GetOrderItemsByOrderQuery getOrderItemsByOrderQuery = new GetOrderItemsByOrderQuery() { OrderId = orderId };
            return Ok(await _mediator.Send(getOrderItemsByOrderQuery));
        }
    }
}
