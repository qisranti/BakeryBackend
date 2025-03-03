using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class OrderEntity: BaseEntity, IAuditableEntity
    {
        public int OfficeId { get; set; }
        public OfficeEntity Office { get; set; } = default!;
        public float Order_Total_Cost { get; set; }
        public int Order_Status { get; set; } = 0;
        public ICollection<OrderItemEntity> Items { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
