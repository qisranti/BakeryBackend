using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Chefs.Commands;
using FinalBakery.Application.Features.Chefs.Queries;
using FinalBakery.Application.Features.Ingredients.Commands;
using FinalBakery.Application.Features.Offices.Queries;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ChefsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createChef")]
        public async Task<IActionResult> CreateChef([FromQuery] string chefName, [FromQuery] int specialtyBreadId)
        {
            ChefDTO chefDTO = new ChefDTO();
            chefDTO.Chef_Name = chefName;
            chefDTO.SpecialtyBreadId = specialtyBreadId;
            chefDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreateChefCommand createChefCommand = new CreateChefCommand()
            {
                ChefDto = chefDTO,
            };

            CreateComandResponse<Chef> response = await _mediator.Send(createChefCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("getAllChefs")]
        public async Task<IActionResult> GetAllChefs()
        {
            GetAllChefsQuery getAllChefsQuery = new GetAllChefsQuery();
            return Ok(await _mediator.Send(getAllChefsQuery));
        }
    }
}
