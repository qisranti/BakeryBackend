using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class IngredientsEntity: BaseEntity, IAuditableEntity
    {
        public int BreadInstanceId { get; set; }
        public string Ingredient_Name { get; set; } = string.Empty;
        public int Ingredient_Quantity { get; set; }
        public BreadInstanceEntity BreadInstance { get; set; } = default!;
        public AuditInfo Audit { get; set; } = default!;

    }
}
