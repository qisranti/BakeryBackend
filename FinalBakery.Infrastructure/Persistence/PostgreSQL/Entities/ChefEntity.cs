using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class ChefEntity: BaseEntity, IAuditableEntity
    {
        public string Chef_Name { get; set; } = string.Empty;
        public int SpecialtyBreadId { get; set; }
        public OfficeEntity Office { get; set; } = new OfficeEntity();
        public BreadEntity SpecialtyBread { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
