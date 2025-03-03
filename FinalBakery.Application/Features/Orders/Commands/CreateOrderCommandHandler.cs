using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Preparations.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.Orders.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateComandResponse<Order>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<CreateOrderCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, ILogger<CreateOrderCommandHandler> logger, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                Order order = await _orderRepository.GetByIdAsync(request.OrderDto.Id);
                if (order != null)
                    return new CreateComandResponse<Order>(order, "Success", true);
                Order orderToCreate = _mapper.Map<Order>(request.OrderDto);
                Order orderCreated = await _orderRepository.AddAsync(orderToCreate);
                return new CreateComandResponse<Order>(orderCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating the Order {request.OrderDto}: {ex.Message}");
                return new CreateComandResponse<Order>(null, "Error", false);
            }
        }
    }
}
