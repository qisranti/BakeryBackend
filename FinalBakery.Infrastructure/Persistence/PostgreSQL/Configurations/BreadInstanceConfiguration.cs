using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class BreadInstanceConfiguration : IEntityTypeConfiguration<BreadInstanceEntity>
    {
        public void Configure(EntityTypeBuilder<BreadInstanceEntity> builder)
        {
            builder.ToTable("bread_instance");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<BreadInstanceEntity> builder)
        {
            builder.HasKey(breadInstance => breadInstance.Id);
        }

        private void ConfigureRelationShips(EntityTypeBuilder<BreadInstanceEntity> builder)
        {
            builder.HasOne(breadInstance => breadInstance.OrderItemEntity)
                .WithOne(orderItem => orderItem.BreadInstance)
                .HasForeignKey<BreadInstanceEntity>(bread => bread.Id)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasMany(breadInstance => breadInstance.BreadIngredients)
                .WithOne(ingredient => ingredient.BreadInstance)
                .HasForeignKey(ingredient => ingredient.BreadInstanceId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(breadInstance => breadInstance.BreadPreparation)
                .WithOne(preparation => preparation.BreadInstance)
                .HasForeignKey(preparation => preparation.BreadInstanceId)
                .OnDelete(DeleteBehavior.Cascade);
                
        }
    }
}
