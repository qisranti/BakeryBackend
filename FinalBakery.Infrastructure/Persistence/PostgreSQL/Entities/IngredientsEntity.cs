using FinalBakery.Domain.Common;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities
{
    public class IngredientsEntity: BaseEntity, IAuditableEntity
    {
        public string Ingredient_Name { get; set; } = string.Empty;
        public int Ingredient_Quantity { get; set; }
        public ICollection<BreadInstanceIngredientEntity> BreadInstances { get; set; } = [];
        public AuditInfo Audit { get; set; } = default!;

    }
}
