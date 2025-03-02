
using FinalBakery.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public static class AuditConfiguration
    {
        public static void Configure<T>(EntityTypeBuilder<T> builder)
           where T : class, IAuditableEntity
        {
            builder.OwnsOne(entity => entity.Audit, audit =>
            {
                audit.Property(a => a.CreatedBy)
                    .HasColumnName("created_by")
                    .IsRequired();

                audit.Property(a => a.UpdatedBy)
                    .HasColumnName("updated_by")
                    .IsRequired();

                audit.Property(a => a.CreatedDate)
                    .HasColumnName("created_at")
                    .HasConversion(
                        valueToInsert => valueToInsert.ToUniversalTime(),
                        valueToReturn => DateTime.SpecifyKind(
                            valueToReturn,
                            DateTimeKind.Utc
                        )
                    )
                    .IsRequired();

                audit.Property(a => a.UpdatedDate)
                    .HasColumnName("updated_at")
                    .HasConversion(
                        valueToInsert => valueToInsert.HasValue
                            ? valueToInsert.Value.ToUniversalTime()
                            : (DateTime?)null,
                        valueToReturn => valueToReturn.HasValue
                            ? DateTime.SpecifyKind(
                                valueToReturn.Value,
                                DateTimeKind.Utc
                            )
                            : (DateTime?)null
                    )
                    .IsRequired(false);
            });
        }
    }
}
