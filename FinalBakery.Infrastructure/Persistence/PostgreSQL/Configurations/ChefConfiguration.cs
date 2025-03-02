using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class ChefConfiguration : IEntityTypeConfiguration<ChefEntity>
    {
        public void Configure(EntityTypeBuilder<ChefEntity> builder)
        {
            builder.ToTable("chefs");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<ChefEntity> builder)
        {
            builder.HasKey(chef => chef.Id);
            builder.Property(chef => chef.Chef_Name)
                .HasColumnName("chef_name")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<ChefEntity> builder)
        {
            builder.HasOne(chef => chef.SpecialtyBread)
                   .WithMany(bread => bread.Chefs)
                   .HasForeignKey(chef => chef.SpecialtyBreadId)
                   .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
