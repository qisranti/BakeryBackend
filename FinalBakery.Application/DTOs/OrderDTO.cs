using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.DTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int OfficeId { get; set; } = default!;
        public int Order_Total_Cost { get; set; } = 0;
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        public AuditInfo Audit { get; set; } = default!;
    }
}
