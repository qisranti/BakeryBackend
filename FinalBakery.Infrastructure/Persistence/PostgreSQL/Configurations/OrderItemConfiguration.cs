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
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItemEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.ToTable("order_items");
            ConfigureColumns(builder);
            ConfigureRelationShips(builder);
            AuditConfiguration.Configure(builder);
        }

        private void ConfigureColumns(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasKey(orderItem => orderItem.Id);
            builder.Property(orderItem => orderItem.OrderItem_Quantity)
                .HasColumnName("order_item_quantity")
                .IsRequired();
            builder.Property(orderItem => orderItem.OrderItem_Cost)
                .HasColumnName("order_item_cost")
                .IsRequired();
        }

        private void ConfigureRelationShips(EntityTypeBuilder<OrderItemEntity> builder)
        {
            builder.HasOne(orderItem => orderItem.Bread)
                .WithMany(breadInstance => breadInstance.OrderItems)
                .HasForeignKey(orderItem => orderItem.BreadId)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.HasOne(orderItem => orderItem.Order)
                .WithMany(order => order.Items)
                .HasForeignKey(orderItem => orderItem.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(orderItem => orderItem.Bread)
                .WithMany()
                .HasForeignKey(orderItem => orderItem.BreadId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
