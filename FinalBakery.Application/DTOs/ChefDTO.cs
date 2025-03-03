using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Application.DTOs
{
    public class ChefDTO
    {
        public string Chef_Name { get; set; } = string.Empty;
        public int SpecialtyBreadId { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
