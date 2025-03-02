using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class OrderInstanceEntity : BaseEntity, IAuditableEntity
    {
        public ICollection<OrderItemEntity> Items { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
