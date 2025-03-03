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
    public class OfficeConfiguration : IEntityTypeConfiguration<OfficeEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.ToTable("office");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.HasKey(office => office.Id);
            builder.Property(office => office.Office_Name)
                .HasColumnName("office_name")
                .IsRequired();
            builder.Property(office => office.Office_Capacity)
                .HasColumnName("office_capacity")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<OfficeEntity> builder)
        {
            builder.HasOne(office => office.Chef)
                   .WithOne(chef => chef.Office)
                   .HasForeignKey<OfficeEntity>(office => office.ChefId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(office => office.Office_Menu)
                .WithMany(bread => bread.Offices)
                .UsingEntity<OfficeBreadEntity>(
                    j => j.HasOne(ob => ob.Bread)
                        .WithMany(b => b.OfficesBreads)
                        .HasForeignKey(ob => ob.BreadId),
                    j => j.HasOne(ob => ob.Office)
                        .WithMany(o => o.OfficeBreads)
                        .HasForeignKey(ob => ob.OfficeId),
                    j =>
                    {
                        j.HasKey(ob => new { ob.OfficeId, ob.BreadId });
                    }
                );
        }

    }
}
