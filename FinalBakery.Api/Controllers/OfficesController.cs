using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Breads.Commands;
using FinalBakery.Application.Features.Breads.Queries;
using FinalBakery.Application.Features.Ingredients.Queries;
using FinalBakery.Application.Features.Offices.Commands;
using FinalBakery.Application.Features.Offices.Queries;
using FinalBakery.Application.Features.OrderItems.Queries;
using FinalBakery.Application.Features.Orders.Queries;
using FinalBakery.Application.Features.Preparations.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createOffice")]
        public async Task<IActionResult> CreateOffice([FromQuery] string officeName, [FromQuery] int officeCapacity)
        {
            OfficeDTO officeDTO = new OfficeDTO();
            officeDTO.Office_Name = officeName;
            officeDTO.Office_Capacity = officeCapacity;
            officeDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreateOfficeCommand createOfficeCommand = new CreateOfficeCommand()
            {
                OfficeDto = officeDTO,
            };

            CreateComandResponse<Office> response = await _mediator.Send(createOfficeCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("assignChef")]
        public async Task<IActionResult> AssignChefToOffice([FromQuery] int chefId, [FromQuery] int officeId)
        {
            try
            {
                UpdateAssignedChefCommand updateAssignedChefCommand = new UpdateAssignedChefCommand()
                {
                    ChefId = chefId,
                    OfficeId = officeId,
                };
                return Ok(await _mediator.Send(updateAssignedChefCommand));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while assigning the chef.", error = ex.Message });
            }
        }


        [HttpGet("getAllOffices")]
        public async Task<IActionResult> GetOffices()
        {
            GetAllOfficesQuery getAllOfficesQuery = new GetAllOfficesQuery();
            return Ok(await _mediator.Send(getAllOfficesQuery));
        }

        [HttpGet("getOfficeOrders")]
        public async Task<IActionResult> GetOfficeOrders([FromQuery] int officeId)
        {
            GetOfficeOrdersQuery getOfficeOrdersQuery = new GetOfficeOrdersQuery() { OfficeId = officeId };
            return Ok(await _mediator.Send(getOfficeOrdersQuery));
        }

        [HttpGet("getMenu")]
        public async Task<IActionResult> GetOfficeMenu([FromQuery] int officeId)
        {
            GetOfficeMenuQuery getOfficeMenu = new GetOfficeMenuQuery() { OfficeId = officeId };
            return Ok(await _mediator.Send(getOfficeMenu));
        }

        [HttpGet("getTodayEarnings")]
        public async Task<IActionResult> GetEarnings([FromQuery] int officeId)
        {
            CalculateEarningsQuery calculateEarningsQuery = new CalculateEarningsQuery()
            {
                OfficeId = officeId
            };
            CreateComandResponse<OfficeEarnings> response = await _mediator.Send(calculateEarningsQuery);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("prepareOfficeOrders")]
        public async Task<IActionResult> PrepareOfficeOrders([FromQuery] int officeId)
        {
            PrepareOfficeOrdersCommand prepareOfficeOrdersCommand = new PrepareOfficeOrdersCommand()
            {
                OfficeId = officeId
            };
            CreateComandResponse<List<OrderPreparation>> response = await _mediator.Send(prepareOfficeOrdersCommand);
            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }


        [HttpPost("addBreadToOfficeMenu")]
        public async Task<IActionResult> AddBreadToOfficeMenu([FromQuery] int breadId, [FromQuery] int officeId)
        {
            OfficeBreadDTO officeBreadDTO = new OfficeBreadDTO();
            officeBreadDTO.BreadId = breadId;
            officeBreadDTO.OfficeId = officeId;
            officeBreadDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            AddBreadToOfficeMenuCommand addBreadToOfficeMenuCommand = new AddBreadToOfficeMenuCommand()
            {
                OfficeBreadDTO = officeBreadDTO,
            };

            CreateComandResponse<OfficeBread> response = await _mediator.Send(addBreadToOfficeMenuCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
