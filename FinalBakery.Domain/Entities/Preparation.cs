using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Preparation : BaseEntity, IAuditableEntity
    {
        public string Step_Name { get; set; } = string.Empty;
        public float Step_Duration { get; set; }
        public int Step_Order { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
