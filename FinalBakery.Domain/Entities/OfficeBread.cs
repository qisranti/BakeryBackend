using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class OfficeBread
    {
        public int OfficeId { get; set; }

        public int BreadId { get; set; }

        public AuditInfo Audit { get; set; } = default!;
    }
}
