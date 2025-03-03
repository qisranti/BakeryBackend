using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;
using FinalBakery.Domain.Entities;

namespace FinalBakery.Application.DTOs
{
    public class OfficeDTO
    {
        public string Office_Name { get; set; } = string.Empty;
        public int Office_Capacity { get; set; }
        public int? ChefId { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
