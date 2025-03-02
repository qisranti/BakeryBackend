using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class PreparationEntity: BaseEntity, IAuditableEntity
    {
        public int BreadInstanceId { get; set; }
        public string Step_Name { get; set; } = string.Empty;
        public float Step_Duration { get; set; }
        public BreadInstanceEntity BreadInstance { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
