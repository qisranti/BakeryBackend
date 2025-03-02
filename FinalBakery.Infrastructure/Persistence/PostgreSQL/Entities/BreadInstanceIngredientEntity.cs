using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class BreadInstanceIngredientEntity : BaseEntity, IAuditableEntity
    {
        public int BreadInstanceId { get; set; }
        public BreadInstanceEntity BreadInstance { get; set; } = default!;

        public int IngredientId { get; set; }
        public IngredientsEntity Ingredient { get; set; } = default!;

        public AuditInfo Audit { get; set; } = default!;
    }
}
