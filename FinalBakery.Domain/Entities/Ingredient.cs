using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class Ingredient : BaseEntity, IAuditableEntity
    {
        public string Ingredient_Name { get; set; } = string.Empty;
        public int Ingredient_Quantity { get; set; }
        public AuditInfo Audit { get; set; } = default!;
    }
}
