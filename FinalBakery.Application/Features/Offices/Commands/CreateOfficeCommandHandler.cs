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

namespace FinalBakery.Application.Features.Offices.Commands
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, CreateComandResponse<Office>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly ILogger<CreateOfficeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOfficeCommandHandler(IOfficeRepository officeRepository, ILogger<CreateOfficeCommandHandler> logger, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Office>> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Office office = await _officeRepository.GetByNameAsync(request.OfficeDto.Office_Name);
                if (office != null)
                    return new CreateComandResponse<Office>(office, "Success", true);
                Office officeToCreate = _mapper.Map<Office>(request.OfficeDto);
                Office officeCreated = await _officeRepository.AddAsync(officeToCreate);
                return new CreateComandResponse<Office>(officeCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating the Office {request.OfficeDto}: {ex.Message}");
                return new CreateComandResponse<Office>(null, "Error", false);
            }
        }
    }
}
