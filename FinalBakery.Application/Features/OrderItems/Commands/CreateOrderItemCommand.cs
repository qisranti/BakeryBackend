using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.OrderItems.Commands
{
    public class CreateOrderItemCommand : IRequest<CreateComandResponse<OrderItem>>
    {
        public OrderItemDTO? OrderItemDto { get; set; }
    }
}
