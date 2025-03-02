using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class BreadInstanceIngredientConfiguration : IEntityTypeConfiguration<BreadInstanceIngredientEntity>
    {
        public void Configure(EntityTypeBuilder<BreadInstanceIngredientEntity> builder)
        {
            builder.ToTable("bread_ingredient_instance");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<BreadInstanceIngredientEntity> builder)
        {
            builder.HasKey(breadInstance => breadInstance.Id);
        }

        private void ConfigureRelationShips(EntityTypeBuilder<BreadInstanceIngredientEntity> builder)
        {
            builder.HasOne(breadInstance => breadInstance.BreadInstance)
                   .WithMany(bread => bread.BreadIngredients)
                   .HasForeignKey(breadInstance => breadInstance.BreadInstanceId);
            
            builder.HasOne(bi => bi.Ingredient)
                   .WithMany(i => i.BreadInstances)
                   .HasForeignKey(bi => bi.IngredientId);
        }

    }
}
