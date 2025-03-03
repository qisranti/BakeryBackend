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
    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, CreateComandResponse<BreadIngredient>>
    {
        private readonly IBreadIngredientRepository _breadIngredientRepository;
        private readonly ILogger<AddIngredientCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddIngredientCommandHandler(IBreadIngredientRepository breadIngredientRepository, ILogger<AddIngredientCommandHandler> logger, IMapper mapper)
        {
            _breadIngredientRepository = breadIngredientRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<BreadIngredient>> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BreadIngredient breadIngredient = await _breadIngredientRepository.AddIngredient(request.BreadIngredientDto.BreadInstanceId, request.BreadIngredientDto.IngredientId);
                if (breadIngredient != null)
                    return new CreateComandResponse<BreadIngredient>(breadIngredient, "Success", true);
                BreadIngredient breadIngredientToCreate = _mapper.Map<BreadIngredient>(request.BreadIngredientDto);
                BreadIngredient breadIngredientCreated = await _breadIngredientRepository.AddAsync(breadIngredientToCreate);
                return new CreateComandResponse<BreadIngredient>(breadIngredientCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding ingredient {request.BreadIngredientDto}: {ex.Message}");
                return new CreateComandResponse<BreadIngredient>(null, "Error", false);
            }
        }
    }
}
