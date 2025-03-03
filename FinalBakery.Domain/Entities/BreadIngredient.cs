using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Domain.Entities
{
    public class BreadIngredient : BaseEntity, IAuditableEntity
    {
        public int BreadInstanceId { get; set; }

        public int IngredientId { get; set; }

        public AuditInfo Audit { get; set; } = default!;
    }
}
