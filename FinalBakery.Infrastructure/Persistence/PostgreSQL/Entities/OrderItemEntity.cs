using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class OrderItemEntity: BaseEntity, IAuditableEntity
    {
        public int OrderId { get; set; }
        public int BreadId { get; set; }
        public BreadInstanceEntity BreadInstance { get; set; } = default!;
        public BreadEntity Bread { get; set; } = default!;
        public OrderEntity Order { get; set; } = default!;
        public float OrderItem_Cost { get; set; }
        public int OrderItem_Quantity { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
