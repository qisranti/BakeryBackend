using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Ingredients.Commands;
using FinalBakery.Application.Features.Ingredients.Queries;
using FinalBakery.Application.Features.Preparations.Commands;
using FinalBakery.Application.Features.Preparations.Queries;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreparationsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PreparationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createPreparationStep")]
        public async Task<IActionResult> CreatePreparationStep([FromQuery] string stepName, [FromQuery] float stepDuration, [FromQuery] int stepOrder)
        {
            PreparationDTO preparationDTO = new PreparationDTO();
            preparationDTO.Step_Name = stepName;
            preparationDTO.Step_Duration = stepDuration;
            preparationDTO.Step_Order = stepOrder;
            preparationDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreatePreparationCommand createPreparationCommand = new CreatePreparationCommand()
            {
                PreparationDto = preparationDTO,
            };

            CreateComandResponse<Preparation> response = await _mediator.Send(createPreparationCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("getBreadPreparation")]
        public async Task<IActionResult> GetBreadPreparation([FromQuery] int breadId)
        {
            GetPreparationStepsByBreadQuery getPreparationStepsByBreadQuery = new GetPreparationStepsByBreadQuery() { BreadId = breadId };
            return Ok(await _mediator.Send(getPreparationStepsByBreadQuery));
        }
    }
}
