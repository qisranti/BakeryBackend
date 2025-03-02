using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Chef : BaseEntity, IAuditableEntity
    {
        public string Chef_Name { get; set; } = string.Empty;
        public Bread Chef_Specialty { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;
    }
}
