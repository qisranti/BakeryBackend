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
                OrderItem orderItem = await _orderItemRepository.GetByIdAsync(request.OrderItemDto.Id);
                if (orderItem != null)
                    return new CreateComandResponse<OrderItem>(orderItem, "Success", true);
                OrderItem orderItemToCreate = _mapper.Map<OrderItem>(request.OrderItemDto);
                OrderItem orderItemCreated = await _orderItemRepository.AddAsync(orderItemToCreate);
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
