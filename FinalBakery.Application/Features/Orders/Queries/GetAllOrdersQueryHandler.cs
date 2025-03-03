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
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private readonly IOrderRepository _repository;
        private readonly ILogger<GetAllOrdersQueryHandler> _logger;

        public GetAllOrdersQueryHandler(IOrderRepository repository, ILogger<GetAllOrdersQueryHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var listOfOrders = await _repository.GetAllOrders();
            return listOfOrders;
        }
    }
}
