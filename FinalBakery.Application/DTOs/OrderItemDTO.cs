using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Application.DTOs
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int BreadId { get; set; }
        public int OrderId { get; set; }
        public int OrderItem_Cost { get; set; }
        public int OrderItem_Quantity { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
