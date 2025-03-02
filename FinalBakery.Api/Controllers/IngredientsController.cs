using FinalBakery.Application.DTOs;
using FinalBakery.Application.Features.Ingredients.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalBakery.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public IngredientsController(IMediator mediator)
        {
            _mediator = mediator;       
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateIngredient([FromQuery] string ingredientName, [FromQuery] int ingredientQuantity)
        {
            IngredientDTO ingredientDTO = new IngredientDTO();
            ingredientDTO.Ingredient_Name = ingredientName;
            ingredientDTO.Ingredient_Quantity = ingredientQuantity;
            ingredientDTO.Audit = new Domain.Common.AuditInfo()
            {
                CreatedBy = "Isra",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };

            CreateIngredientCommand createIngredientCommand = new CreateIngredientCommand()
            {
                IngredientDto = ingredientDTO,
            };

            CreateComandResponse<Ingredient> response = await _mediator.Send(createIngredientCommand);

            if (response.Success)
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
