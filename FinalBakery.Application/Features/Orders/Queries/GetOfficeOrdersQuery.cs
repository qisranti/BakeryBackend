using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Entities;
using MediatR;

namespace FinalBakery.Application.Features.Orders.Queries
{
    public class GetOfficeOrdersQuery : IRequest<List<Order>>
    {
        public int OfficeId { get; set; }
    }
}
