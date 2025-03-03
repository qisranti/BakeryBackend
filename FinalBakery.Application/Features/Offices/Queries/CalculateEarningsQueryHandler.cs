using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Offices.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Offices.Queries
{
    public class CalculateEarningsQueryHandler : IRequestHandler<CalculateEarningsQuery, CreateComandResponse<OfficeEarnings>>
    {
        private readonly ICalculateEarningsRepository _repository;
        private readonly ILogger<CalculateEarningsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public CalculateEarningsQueryHandler(ICalculateEarningsRepository repository, ILogger<CalculateEarningsQueryHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<OfficeEarnings>> Handle(CalculateEarningsQuery request, CancellationToken cancellationToken)
        {
            try
            {
                OfficeEarnings orderPreparations = await _repository.CalculateOfficeEarnings(request.OfficeId);
                return new CreateComandResponse<OfficeEarnings>(orderPreparations, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred Calculating the Office Earnings {request.OfficeId}: {ex.Message}");
                return new CreateComandResponse<OfficeEarnings>(null, "Error", false);
            }
        }
    }
}
