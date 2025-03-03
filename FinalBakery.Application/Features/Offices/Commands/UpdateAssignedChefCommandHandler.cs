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

namespace FinalBakery.Application.Features.Offices.Commands
{
    public class UpdateAssignedChefCommandHandler : IRequestHandler<UpdateAssignedChefCommand, CreateComandResponse<Office>>
    {
        private readonly IOfficeRepository _repository;
        private readonly ILogger<UpdateAssignedChefCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateAssignedChefCommandHandler(IOfficeRepository repository, ILogger<UpdateAssignedChefCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Office>> Handle(UpdateAssignedChefCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Office officeEntity = await _repository.AssignChefAsync(request.ChefId, request.OfficeId);
                if (officeEntity != null)
                    return new CreateComandResponse<Office>(officeEntity, "Success", true);
                Office officeUpdated = await _repository.AssignChefAsync(request.ChefId, request.OfficeId);
                return new CreateComandResponse<Office>(officeUpdated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding the Chef to the Office {request.ChefId}: {ex.Message}");
                return new CreateComandResponse<Office>(null, "Error", false);
            }
        }
    }
}
