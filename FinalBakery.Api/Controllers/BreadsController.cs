using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Breads.Commands;
using FinalBakery.Application.Features.Breads.Queries;
using FinalBakery.Application.Features.Chefs.Commands;
using FinalBakery.Application.Features.Offices.Queries;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BreadsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BreadsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createBread")]
        public async Task<IActionResult> CreateBread([FromQuery] string breadName, [FromQuery] int breadCost)
        {
            BreadDTO breadDTO = new BreadDTO();
            breadDTO.Bread_Name = breadName;
            breadDTO.Bread_Cost = breadCost;
            breadDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreateBreadCommand createBreadCommand = new CreateBreadCommand()
            {
                BreadDTO = breadDTO,
            };

            CreateComandResponse<Bread> response = await _mediator.Send(createBreadCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("AddIngredient")]
        public async Task<IActionResult> AddIngredient([FromQuery] int breadId, [FromQuery] int ingredientId)
        {
            BreadIngredientDTO breadIngredientDTO = new BreadIngredientDTO();
            breadIngredientDTO.BreadInstanceId = breadId;
            breadIngredientDTO.IngredientId = ingredientId;
            breadIngredientDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            AddIngredientCommand addIngredientCommand = new AddIngredientCommand()
            {
                BreadIngredientDto = breadIngredientDTO,
            };

            CreateComandResponse<BreadIngredient> response = await _mediator.Send(addIngredientCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("AddNewIngredient")]
        public async Task<IActionResult> AddNewIngredient([FromQuery] int breadId, [FromQuery] string ingredientName, [FromQuery] int ingredientQuantity)
        {
            
            AddNewIngredientCommand addNewIngredientCommand = new AddNewIngredientCommand()
            {
                BreadId = breadId,
                IngredientName = ingredientName,
                IngredientQuantity = ingredientQuantity,
            };

            CreateComandResponse<BreadIngredient> response = await _mediator.Send(addNewIngredientCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("AddPreparationStep")]
        public async Task<IActionResult> AddPreparationStep([FromQuery] int breadId, [FromQuery] int preparationId)
        {
            BreadPreparationDTO breadPreparationDTO = new BreadPreparationDTO();
            breadPreparationDTO.BreadInstanceId = breadId;
            breadPreparationDTO.PreparationId = preparationId;
            breadPreparationDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            AddPreparationStepCommand addPreparationStepCommand = new AddPreparationStepCommand()
            {
                BreadPreparationDto = breadPreparationDTO,
            };

            CreateComandResponse<BreadPreparation> response = await _mediator.Send(addPreparationStepCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost("AddNewPreparationStep")]
        public async Task<IActionResult> AddNewPreparationStep([FromQuery] int breadId, [FromQuery] string stepName, [FromQuery] int stepDuration, [FromQuery] int stepOrder)
        {

            AddNewPreparationStepCommand addNewPreparationStepCommand = new AddNewPreparationStepCommand()
            {
                BreadId = breadId,
                StepName = stepName,
                StepDuration = stepDuration,
                StepOrder = stepOrder
            };

            CreateComandResponse<BreadPreparation> response = await _mediator.Send(addNewPreparationStepCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpGet("GetAllBreads")]
        public async Task<IActionResult> GetAllBreads()
        {
            GetAllBreadsQuery getAllBreadsQuery = new GetAllBreadsQuery();
            return Ok(await _mediator.Send(getAllBreadsQuery));
        }
    }
}
