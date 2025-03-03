using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Chefs.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Breads.Commands
{
    public class CreateBreadCommandHandler : IRequestHandler<CreateBreadCommand, CreateComandResponse<Bread>>
    {
        private readonly IBreadRepository _breadRepository;
        private readonly ILogger<CreateBreadCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateBreadCommandHandler(IBreadRepository breadRepository, ILogger<CreateBreadCommandHandler> logger, IMapper mapper)
        {
            _breadRepository = breadRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Bread>> Handle(CreateBreadCommand request, CancellationToken cancellationToken)
        {
            try
            {

                Bread bread = await _breadRepository.GetByNameAsync(request.BreadDTO.Bread_Name);
                if (bread != null)
                    return new CreateComandResponse<Bread>(bread, "Success", true);
                Bread breadToCreate = _mapper.Map<Bread>(request.BreadDTO);
                Bread breadCreated = await _breadRepository.AddAsync(breadToCreate);
                return new CreateComandResponse<Bread>(breadCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating ingredient {request.BreadDTO}: {ex.Message}");
                return new CreateComandResponse<Bread>(null, "Error", false);
            }
        }
    }
}
