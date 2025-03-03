using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Preparations.Queries;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.OrderItems.Queries
{
    public class GetOrderItemsByOrderQueryHandler : IRequestHandler<GetOrderItemsByOrderQuery, List<OrderItem>>
    {
        private readonly IOrderItemRepository _repository;
        private readonly ILogger<GetOrderItemsByOrderQueryHandler> _logger;

        public GetOrderItemsByOrderQueryHandler(IOrderItemRepository repository, ILogger<GetOrderItemsByOrderQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<OrderItem>> Handle(GetOrderItemsByOrderQuery request, CancellationToken cancellationToken)
        {
            var listOfPreparationSteps = await _repository.GetOrderItemsByOrderId(request.OrderId);
            return listOfPreparationSteps;
        }
    }
}
