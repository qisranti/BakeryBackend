using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class BreadConfiguration : IEntityTypeConfiguration<BreadEntity>
    {
        public void Configure(EntityTypeBuilder<BreadEntity> builder)
        {
            builder.ToTable("bread");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<BreadEntity> builder)
        {
            builder.HasKey(bread => bread.Id);
            builder.Property(bread => bread.Bread_Name)
                .HasColumnName("bread_name")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<BreadEntity> builder)
        {
            builder.HasMany(bread => bread.Offices)
                .WithMany(office => office.Office_Menu)
                .UsingEntity<OfficeBreadEntity>(
                    j => j.HasOne(ob => ob.Office)
                        .WithMany(o => o.OfficeBreads)
                        .HasForeignKey(ob => ob.OfficeId),
                    j => j.HasOne(ob => ob.Bread)
                        .WithMany(b => b.OfficesBreads)
                        .HasForeignKey(ob => ob.BreadId),
                    j =>
                    {
                        j.HasKey(ob => new { ob.OfficeId, ob.BreadId });
                    }
                );
        }

    }
}
