using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Application.DTOs;
using FinalBakery.Application.Models;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Orders.Commands
{
    public class CreateOrderCommand : IRequest<CreateComandResponse<Order>>
    {
        public OrderDTO? OrderDto { get; set; }
    }
}
