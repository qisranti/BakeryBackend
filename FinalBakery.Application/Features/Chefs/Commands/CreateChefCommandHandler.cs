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

namespace FinalBakery.Application.Features.Chefs.Commands
{
    internal class CreateChefCommandHandler : IRequestHandler<CreateChefCommand, CreateComandResponse<Chef>>
    {
        private readonly IChefRepository _chefRepository;
        private readonly ILogger<CreateChefCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateChefCommandHandler(IChefRepository chefRepository, ILogger<CreateChefCommandHandler> logger, IMapper mapper)
        {
            _chefRepository = chefRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Chef>> Handle(CreateChefCommand request, CancellationToken cancellationToken)
        {
            try
            {
                   
                Chef chef = await _chefRepository.GetByNameAsync(request.ChefDto.Chef_Name);
                if (chef != null)
                    return new CreateComandResponse<Chef>(chef, "Success", true);
                Chef chefToCreate = _mapper.Map<Chef>(request.ChefDto);
                Chef chefCreated = await _chefRepository.AddAsync(chefToCreate);
                return new CreateComandResponse<Chef>(chefCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating Chef {request.ChefDto}: {ex.Message}");
                return new CreateComandResponse<Chef>(null, "Error", false);
            }
        }
    }
}
