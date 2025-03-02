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
    public class BreadInstancePreparationConfiguration : IEntityTypeConfiguration<BreadInstancePreparationEntity>
    {
        public void Configure(EntityTypeBuilder<BreadInstancePreparationEntity> builder)
        {
            builder.ToTable("bread_preparation_instance");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<BreadInstancePreparationEntity> builder)
        {
            builder.HasKey(breadInstance => breadInstance.Id);
        }

        private void ConfigureRelationShips(EntityTypeBuilder<BreadInstancePreparationEntity> builder)
        {
            builder.HasOne(breadInstance => breadInstance.BreadInstance)
                   .WithMany(bread => bread.BreadPreparation)
                   .HasForeignKey(breadInstance => breadInstance.BreadInstanceId);

            builder.HasOne(bi => bi.Preparation)
                   .WithMany(i => i.BreadInstances)
                   .HasForeignKey(bi => bi.PreparationId);
        }

    }
}
