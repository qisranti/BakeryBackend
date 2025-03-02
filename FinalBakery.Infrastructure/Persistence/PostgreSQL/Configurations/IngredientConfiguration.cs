
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class IngredientConfiguration : IEntityTypeConfiguration<IngredientsEntity>
    {
        public void Configure(EntityTypeBuilder<IngredientsEntity> builder) 
        {
            builder.ToTable("ingredients");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<IngredientsEntity> builder) 
        { 
            builder.HasKey(ingredient => ingredient.Id);
            builder.Property(ingredient => ingredient.Ingredient_Name)
                .HasColumnName("ingredient_name")
                .IsRequired();
            builder.Property(ingredient => ingredient.Ingredient_Quantity)
                .HasColumnName("ingredient_quantity")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<IngredientsEntity> builder) 
        {
            builder.HasOne(ingredient => ingredient.BreadInstance)
                .WithMany(breadInstance => breadInstance.Ingredients)
                .HasForeignKey(ingredients => ingredients.BreadInstanceId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
