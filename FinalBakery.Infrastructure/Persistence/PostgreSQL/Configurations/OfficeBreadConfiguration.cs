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
    internal class OfficeBreadConfiguration : IEntityTypeConfiguration<OfficeBreadEntity>
    {
        public void Configure(EntityTypeBuilder<OfficeBreadEntity> builder)
        {
            builder.ToTable("office_bread");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<OfficeBreadEntity> builder)
        {
            builder.HasKey(officeBread => officeBread.Id);
        }

        private void ConfigureRelationShips(EntityTypeBuilder<OfficeBreadEntity> builder)
        {
            builder.HasOne(officeBread => officeBread.Office)
                .WithMany(office => office.OfficeBreads)
                .HasForeignKey(officeBread => officeBread.OfficeId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(officeBread => officeBread.Bread)
                .WithMany(bread => bread.OfficesBreads)
                .HasForeignKey(officeBread => officeBread.BreadId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
