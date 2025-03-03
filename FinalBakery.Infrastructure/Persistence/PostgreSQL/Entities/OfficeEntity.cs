using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class OfficeEntity: BaseEntity, IAuditableEntity
    {
        public string Office_Name { get; set; } = string.Empty;
        public int Office_Capacity { get; set; }
        public int? ChefId { get; set; }
        public ChefEntity Chef { get; set; } = default!;
        public ICollection<BreadEntity> Office_Menu { get; set; } = default!;
        public ICollection<OfficeBreadEntity> OfficeBreads { get; set; } = default!;
        public ICollection<OrderEntity> OrderEntities { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
