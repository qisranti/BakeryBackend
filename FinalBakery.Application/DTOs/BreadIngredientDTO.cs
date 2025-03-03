using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Application.DTOs
{
    public class BreadIngredientDTO
    {
        public int BreadInstanceId { get; set; }

        public int IngredientId { get; set; }

        public AuditInfo Audit { get; set; } = default!;
    }
}
