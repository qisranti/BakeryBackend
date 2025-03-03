using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Office : BaseEntity, IAuditableEntity
    {
        public string Office_Name { get; set; } = string.Empty;
        public int Office_Capacity { get; set; }
        public int? ChefId { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
