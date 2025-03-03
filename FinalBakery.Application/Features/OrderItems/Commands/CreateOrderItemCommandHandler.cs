using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FinalBakery.Application.Contracts.Persistence;
using FinalBakery.Application.Features.Orders.Commands;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinalBakery.Application.Features.OrderItems.Commands
{
    public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, CreateComandResponse<OrderItem>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly ILogger<CreateOrderItemCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateOrderItemCommandHandler(IOrderItemRepository orderItemRepository, ILogger<CreateOrderItemCommandHandler> logger, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CreateComandResponse<OrderItem>> Handle(CreateOrderItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                OrderItem orderItemCreated = await _orderItemRepository.CreateOrderItem(request.OrderItemDto.OrderId, request.OrderItemDto.BreadId, request.OrderItemDto.OrderItem_Cost, request.OrderItemDto.OrderItem_Quantity);
                return new CreateComandResponse<OrderItem>(orderItemCreated, "Success", true);
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error occurred creating the Order Item {request.OrderItemDto}: {ex.Message}");
                return new CreateComandResponse<OrderItem>(null, "Error", false);
            }
        }
    }
}
