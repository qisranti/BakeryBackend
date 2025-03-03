using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class OfficeBreadEntity : BaseEntity, IAuditableEntity
    {
        public int OfficeId { get; set; }
        public OfficeEntity Office { get; set; } = default!;

        public int BreadId { get; set; }
        public BreadEntity Bread { get; set; } = default!;

        public AuditInfo Audit { get; set; } = default!;
    }
}
