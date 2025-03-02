using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Order : BaseEntity, IAuditableEntity
    {
        public Office Office { get; set; } = default!;
        public int Order_Total_Cost { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = [];
        public AuditInfo Audit { get; set; } = default!;
    }
}
