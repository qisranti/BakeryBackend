using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class OrderItem : BaseEntity, IAuditableEntity
    {
        public int BreadId { get; set; }
        public int OrderId { get; set; }
        public int OrderItem_Cost { get; set; }
        public int OrderItem_Quantity { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
