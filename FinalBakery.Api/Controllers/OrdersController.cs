using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Offices.Commands;
using FinalBakery.Application.Features.Offices.Queries;
using FinalBakery.Application.Features.Orders.Commands;
using FinalBakery.Application.Features.Orders.Queries;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateOffice([FromQuery] int officeId)
        {
            OrderDTO orderDTO = new OrderDTO();
            orderDTO.OfficeId= officeId;
            orderDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreateOrderCommand createOrderCommand = new CreateOrderCommand()
            {
                OrderDto = orderDTO,
            };

            CreateComandResponse<Order> response = await _mediator.Send(createOrderCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("getAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            GetAllOrdersQuery getAllOrdersQuery = new GetAllOrdersQuery();
            return Ok(await _mediator.Send(getAllOrdersQuery));
        }


    }
}
