using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Ingredients.Commands
{
    public class CreateIngredientCommandHandler : IRequestHandler<CreateIngredientCommand, CreateComandResponse<Ingredient>>
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ILogger<CreateIngredientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateIngredientCommandHandler(IIngredientRepository ingredientRepository, ILogger<CreateIngredientCommandHandler> logger, IMapper mapper)
        {
            _ingredientRepository = ingredientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Ingredient>> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Ingredient ingredient = await _ingredientRepository.GetByNameAsync(request.IngredientDto.Ingredient_Name);
                if (ingredient != null)
                    return new CreateComandResponse<Ingredient>(ingredient, "Success", true);
                Ingredient ingredientToCreate = _mapper.Map<Ingredient>(request.IngredientDto);
                Ingredient ingredientCreated = await _ingredientRepository.AddAsync(ingredientToCreate);
                return new CreateComandResponse<Ingredient>(ingredientCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating ingredient {request.IngredientDto}: {ex.Message}");
                return new CreateComandResponse<Ingredient>(null, "Error", false);
            }
        }
    }
}
