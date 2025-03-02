using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class BreadInstanceEntity: BaseEntity, IAuditableEntity
    {
        public OrderItemEntity OrderItemEntity { get; set; } = default!;
        public ICollection<BreadInstanceIngredientEntity> BreadIngredients { get; set; } = [];
        public ICollection<BreadInstancePreparationEntity> BreadPreparation { get; set; } = [];
        public AuditInfo Audit {  get; set; } = default!;
    }
}
