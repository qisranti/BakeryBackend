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
    public class AddPreparationStepCommandHandler : IRequestHandler<AddPreparationStepCommand, CreateComandResponse<BreadPreparation>>
    {
        private readonly IBreadPreparationRepository _breadPreparationRepository;
        private readonly ILogger<AddPreparationStepCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddPreparationStepCommandHandler(IBreadPreparationRepository breadPreparationRepository, ILogger<AddPreparationStepCommandHandler> logger, IMapper mapper)
        {
            _breadPreparationRepository = breadPreparationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<BreadPreparation>> Handle(AddPreparationStepCommand request, CancellationToken cancellationToken)
        {
            try
            {
                BreadPreparation breadPreparation = await _breadPreparationRepository.AddPreparationStep(request.BreadPreparationDto.BreadInstanceId, request.BreadPreparationDto.PreparationId);
                if (breadPreparation != null)
                    return new CreateComandResponse<BreadPreparation>(breadPreparation, "Success", true);
                BreadPreparation breadPreparationToCreate = _mapper.Map<BreadPreparation>(request.BreadPreparationDto);
                BreadPreparation breadPreparationCreated = await _breadPreparationRepository.AddAsync(breadPreparationToCreate);
                return new CreateComandResponse<BreadPreparation>(breadPreparationCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding ingredient {request.BreadPreparationDto}: {ex.Message}");
                return new CreateComandResponse<BreadPreparation>(null, "Error", false);
            }
        }
    }
}
