using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Breads.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Offices.Commands
{
    public class AddBreadToOfficeMenuCommandHandler : IRequestHandler<AddBreadToOfficeMenuCommand, CreateComandResponse<OfficeBread>>
    {
        private readonly IOfficeBreadRepository _repository;
        private readonly ILogger<AddBreadToOfficeMenuCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddBreadToOfficeMenuCommandHandler(IOfficeBreadRepository repository, ILogger<AddBreadToOfficeMenuCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<OfficeBread>> Handle(AddBreadToOfficeMenuCommand request, CancellationToken cancellationToken)
        {
            try
            {
                OfficeBread officeBread = await _repository.AddBreadToMenu(request.OfficeBreadDTO.BreadId, request.OfficeBreadDTO.OfficeId);
                if (officeBread != null)
                    return new CreateComandResponse<OfficeBread>(officeBread, "Success", true);
                OfficeBread officeBreadToCreate = _mapper.Map<OfficeBread>(request.OfficeBreadDTO);
                OfficeBread officeBreadCreated = await _repository.AddAsync(officeBreadToCreate);
                return new CreateComandResponse<OfficeBread>(officeBreadCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred adding the Bread to the office menu {request.OfficeBreadDTO}: {ex.Message}");
                return new CreateComandResponse<OfficeBread>(null, "Error", false);
            }
        }
    }
}
