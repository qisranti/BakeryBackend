using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Application.DTOs
{
    public class PreparationDTO
    {
        public string Step_Name { get; set; } = string.Empty;
        public float Step_Duration { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
