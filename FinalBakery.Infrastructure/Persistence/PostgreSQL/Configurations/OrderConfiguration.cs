using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalBakery.Domain.Common;
using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable("orders");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasKey(order => order.Id);
            builder.Property(order => order.Order_Total_Cost)
                .HasColumnName("order_total_cost")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.HasOne(order => order.Office)
                .WithMany(office => office.OrderEntities)
                .HasForeignKey(order => order.OfficeId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(order => order.Items)
                .WithOne(item => item.Order)
                .HasForeignKey(item => item.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
