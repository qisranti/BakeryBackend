using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class BreadInstancePreparationEntity : BaseEntity, IAuditableEntity
    {
        public int BreadInstanceId { get; set; }
        public BreadEntity BreadInstance { get; set; } = default!;

        public int PreparationId { get; set; }
        public PreparationEntity Preparation { get; set; } = default!;

        public AuditInfo Audit { get; set; } = default!;
    }
}
