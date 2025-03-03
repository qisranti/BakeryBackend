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
    public class PrepareOfficeOrdersCommandHandler : IRequestHandler<PrepareOfficeOrdersCommand, CreateComandResponse<List<OrderPreparation>>>
    {
        private readonly IPrepareOrderRepository _repository;
        private readonly ILogger<PrepareOfficeOrdersCommandHandler> _logger;
        private readonly IMapper _mapper;

        public PrepareOfficeOrdersCommandHandler(IPrepareOrderRepository repository, ILogger<PrepareOfficeOrdersCommandHandler> logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<List<OrderPreparation>>> Handle(PrepareOfficeOrdersCommand request, CancellationToken cancellationToken)
        {
            try
            {
                List<OrderPreparation> orderPreparations = await _repository.PrepareOfficeOrders(request.OfficeId);
                return new CreateComandResponse<List<OrderPreparation>>(orderPreparations, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred Preparing the Office Orders {request.OfficeId}: {ex.Message}");
                return new CreateComandResponse<List<OrderPreparation>>(null, "Error", false);
            }
        }
    }
}
