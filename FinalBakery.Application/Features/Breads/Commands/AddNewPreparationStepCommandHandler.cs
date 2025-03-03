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
    public class AddNewPreparationStepCommandHandler : IRequestHandler<AddNewPreparationStepCommand, CreateComandResponse<BreadPreparation>>
    {
        private readonly IBreadPreparationRepository _repository;
        private readonly ILogger<AddNewPreparationStepCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddNewPreparationStepCommandHandler(IBreadPreparationRepository repository, ILogger<AddNewPreparationStepCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<BreadPreparation>> Handle(AddNewPreparationStepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BreadPreparation breadIngredient = await _repository.AddNewPreparationStep(request.BreadId, request.StepName, request.StepDuration, request.StepOrder);
                if (breadIngredient != null)
                    return new CreateComandResponse<BreadPreparation>(breadIngredient, "Success", true);

                BreadPreparation breadIngredientCreated = await _repository.AddNewPreparationStep(request.BreadId, request.StepName, request.StepDuration, request.StepOrder);
                return new CreateComandResponse<BreadPreparation>(breadIngredientCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding preparation step {request.StepName}: {ex.Message}");
                return new CreateComandResponse<BreadPreparation>(null, "Error", false);
            }
        }
    }
}
