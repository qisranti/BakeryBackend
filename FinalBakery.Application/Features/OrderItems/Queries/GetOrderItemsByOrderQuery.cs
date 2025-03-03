using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.OrderItems.Queries
{
    public class GetOrderItemsByOrderQuery : IRequest<List<OrderItem>>
    {
        public int OrderId { get; set; }
    }
}
