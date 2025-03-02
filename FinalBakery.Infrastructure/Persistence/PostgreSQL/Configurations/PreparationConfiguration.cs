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
    public class PreparationConfiguration : IEntityTypeConfiguration<PreparationEntity>
    {
        public void Configure(EntityTypeBuilder<PreparationEntity> builder)
        {
            builder.ToTable("preparation");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<PreparationEntity> builder)
        {
            builder.HasKey(preparation => preparation.Id);
            builder.Property(preparation => preparation.Step_Name)
                .HasColumnName("step_name")
                .IsRequired();
            builder.Property(preparation => preparation.Step_Duration)
                .HasColumnName("step_duration")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<PreparationEntity> builder)
        {
            builder.HasMany(preparation => preparation.BreadInstances)
                .WithOne(breadInstance => breadInstance.Preparation)
                .HasForeignKey(preparation => preparation.PreparationId);
        }
    }
}
