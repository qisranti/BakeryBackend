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

namespace FinalBakery.Application.Features.Breads.Commands
{
    public class AddNewIngredientCommandHandler : IRequestHandler<AddNewIngredientCommand, CreateComandResponse<BreadIngredient>>
    {
        private readonly IBreadIngredientRepository _breadIngredientRepository;
        private readonly ILogger<AddNewIngredientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddNewIngredientCommandHandler(IBreadIngredientRepository breadIngredientRepository, ILogger<AddNewIngredientCommandHandler> logger, IMapper mapper)
        {
            _breadIngredientRepository = breadIngredientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<BreadIngredient>> Handle(AddNewIngredientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BreadIngredient breadIngredient = await _breadIngredientRepository.AddNewIngredient(request.BreadId, request.IngredientName, request.IngredientQuantity);
                if (breadIngredient != null)
                    return new CreateComandResponse<BreadIngredient>(breadIngredient, "Success", true);
                
                BreadIngredient breadIngredientCreated = await _breadIngredientRepository.AddNewIngredient(request.BreadId, request.IngredientName, request.IngredientQuantity);
                return new CreateComandResponse<BreadIngredient>(breadIngredientCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding ingredient {request.IngredientName}: {ex.Message}");
                return new CreateComandResponse<BreadIngredient>(null, "Error", false);
            }
        }
    }
}
