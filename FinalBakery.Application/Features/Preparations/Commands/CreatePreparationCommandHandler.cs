using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Ingredients.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Preparations.Commands
{
    public class CreatePreparationCommandHandler : IRequestHandler<CreatePreparationCommand, CreateComandResponse<Preparation>>
    {
        private readonly IPreparationRepository _preparationRepository;
        private readonly ILogger<CreatePreparationCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreatePreparationCommandHandler(IPreparationRepository preparationRepository, ILogger<CreatePreparationCommandHandler> logger, IMapper mapper)
        {
            _preparationRepository = preparationRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Preparation>> Handle(CreatePreparationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Preparation preparation = await _preparationRepository.GetByNameAsync(request.PreparationDto.Step_Name);
                if (preparation != null)
                    return new CreateComandResponse<Preparation>(preparation, "Success", true);
                Preparation preparationToCreate = _mapper.Map<Preparation>(request.PreparationDto);
                Preparation preparationCreated = await _preparationRepository.AddAsync(preparationToCreate);
                return new CreateComandResponse<Preparation>(preparationCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating preparation step {request.PreparationDto}: {ex.Message}");
                return new CreateComandResponse<Preparation>(null, ex.Message, false);
            }
        }
    }
}
