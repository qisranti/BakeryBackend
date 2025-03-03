using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.OrderItems.Queries;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Orders.Queries
{
    public class GetOfficeOrdersQueryHandler : IRequestHandler<GetOfficeOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<GetOfficeOrdersQueryHandler> _logger;

        public GetOfficeOrdersQueryHandler(IOrderRepository repository, ILogger<GetOfficeOrdersQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Order>> Handle(GetOfficeOrdersQuery request, CancellationToken cancellationToken)
        {
            var listOfOrders = await _repository.GetOfficeOrders(request.OfficeId);
            return listOfOrders;
        }
    }
}
