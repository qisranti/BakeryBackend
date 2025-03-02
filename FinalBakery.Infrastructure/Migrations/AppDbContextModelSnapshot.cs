﻿// <auto-generated />
using System;
using FinalBakery.Infrastructure.Persistence.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FinalBakery.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BreadInstanceId")
                        .HasColumnType("integer");

                    b.Property<float>("Bread_Cost")
                        .HasColumnType("real");

                    b.Property<string>("Bread_Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("bread_name");

                    b.HasKey("Id");

                    b.HasIndex("BreadInstanceId");

                    b.ToTable("bread", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("bread_instance", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceIngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BreadInstanceId")
                        .HasColumnType("integer");

                    b.Property<int>("IngredientId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BreadInstanceId");

                    b.HasIndex("IngredientId");

                    b.ToTable("bread_ingredient_instance", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstancePreparationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BreadInstanceId")
                        .HasColumnType("integer");

                    b.Property<int>("PreparationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("BreadInstanceId");

                    b.HasIndex("PreparationId");

                    b.ToTable("bread_preparation_instance", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.ChefEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Chef_Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("chef_name");

                    b.Property<int>("SpecialtyBreadId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyBreadId");

                    b.ToTable("chefs", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.IngredientsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Ingredient_Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("ingredient_name");

                    b.Property<int>("Ingredient_Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("ingredient_quantity");

                    b.HasKey("Id");

                    b.ToTable("ingredients", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeBreadEntity", b =>
                {
                    b.Property<int>("OfficeId")
                        .HasColumnType("integer");

                    b.Property<int>("BreadId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.HasKey("OfficeId", "BreadId");

                    b.HasIndex("BreadId");

                    b.ToTable("office_bread", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChefId")
                        .HasColumnType("integer");

                    b.Property<int>("Office_Capacity")
                        .HasColumnType("integer")
                        .HasColumnName("office_capacity");

                    b.Property<string>("Office_Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("office_name");

                    b.HasKey("Id");

                    b.HasIndex("ChefId")
                        .IsUnique();

                    b.ToTable("office", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OfficeId")
                        .HasColumnType("integer");

                    b.Property<float>("Order_Total_Cost")
                        .HasColumnType("real")
                        .HasColumnName("order_total_cost");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId");

                    b.ToTable("orders", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BreadEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("BreadId")
                        .HasColumnType("integer");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<float>("OrderItem_Cost")
                        .HasColumnType("real")
                        .HasColumnName("order_item_cost");

                    b.Property<int>("OrderItem_Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("order_item_quantity");

                    b.HasKey("Id");

                    b.HasIndex("BreadEntityId");

                    b.HasIndex("BreadId");

                    b.HasIndex("OrderId");

                    b.ToTable("order_items", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.PreparationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<float>("Step_Duration")
                        .HasColumnType("real")
                        .HasColumnName("step_duration");

                    b.Property<string>("Step_Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("step_name");

                    b.HasKey("Id");

                    b.ToTable("preparation", (string)null);
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", "BreadInstance")
                        .WithMany()
                        .HasForeignKey("BreadInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("BreadEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("BreadEntityId");

                            b1.ToTable("bread");

                            b1.WithOwner()
                                .HasForeignKey("BreadEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("BreadInstance");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderItemEntity", "OrderItemEntity")
                        .WithOne("BreadInstance")
                        .HasForeignKey("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("BreadInstanceEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("BreadInstanceEntityId");

                            b1.ToTable("bread_instance");

                            b1.WithOwner()
                                .HasForeignKey("BreadInstanceEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("OrderItemEntity");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceIngredientEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", "BreadInstance")
                        .WithMany("BreadIngredients")
                        .HasForeignKey("BreadInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.IngredientsEntity", "Ingredient")
                        .WithMany("BreadInstances")
                        .HasForeignKey("IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("BreadInstanceIngredientEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("BreadInstanceIngredientEntityId");

                            b1.ToTable("bread_ingredient_instance");

                            b1.WithOwner()
                                .HasForeignKey("BreadInstanceIngredientEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("BreadInstance");

                    b.Navigation("Ingredient");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstancePreparationEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", "BreadInstance")
                        .WithMany("BreadPreparation")
                        .HasForeignKey("BreadInstanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.PreparationEntity", "Preparation")
                        .WithMany("BreadInstances")
                        .HasForeignKey("PreparationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("BreadInstancePreparationEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("BreadInstancePreparationEntityId");

                            b1.ToTable("bread_preparation_instance");

                            b1.WithOwner()
                                .HasForeignKey("BreadInstancePreparationEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("BreadInstance");

                    b.Navigation("Preparation");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.ChefEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", "SpecialtyBread")
                        .WithMany("Chefs")
                        .HasForeignKey("SpecialtyBreadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("ChefEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("ChefEntityId");

                            b1.ToTable("chefs");

                            b1.WithOwner()
                                .HasForeignKey("ChefEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("SpecialtyBread");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.IngredientsEntity", b =>
                {
                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("IngredientsEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("IngredientsEntityId");

                            b1.ToTable("ingredients");

                            b1.WithOwner()
                                .HasForeignKey("IngredientsEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeBreadEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", "Bread")
                        .WithMany("OfficesBreads")
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", "Office")
                        .WithMany("OfficeBreads")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("OfficeBreadEntityOfficeId")
                                .HasColumnType("integer");

                            b1.Property<int>("OfficeBreadEntityBreadId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("OfficeBreadEntityOfficeId", "OfficeBreadEntityBreadId");

                            b1.ToTable("office_bread");

                            b1.WithOwner()
                                .HasForeignKey("OfficeBreadEntityOfficeId", "OfficeBreadEntityBreadId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("Bread");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.ChefEntity", "Chef")
                        .WithOne("Office")
                        .HasForeignKey("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", "ChefId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("OfficeEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("OfficeEntityId");

                            b1.ToTable("office");

                            b1.WithOwner()
                                .HasForeignKey("OfficeEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("Chef");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", "Office")
                        .WithMany("OrderEntities")
                        .HasForeignKey("OfficeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("OrderEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("OrderEntityId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("Office");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderItemEntity", b =>
                {
                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("BreadEntityId");

                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", "Bread")
                        .WithMany()
                        .HasForeignKey("BreadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderEntity", "Order")
                        .WithMany("Items")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("OrderItemEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("OrderItemEntityId");

                            b1.ToTable("order_items");

                            b1.WithOwner()
                                .HasForeignKey("OrderItemEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();

                    b.Navigation("Bread");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.PreparationEntity", b =>
                {
                    b.OwnsOne("FinalBakery.Domain.Common.AuditInfo", "Audit", b1 =>
                        {
                            b1.Property<int>("PreparationEntityId")
                                .HasColumnType("integer");

                            b1.Property<string>("CreatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("created_by");

                            b1.Property<DateTime>("CreatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("UpdatedBy")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("updated_by");

                            b1.Property<DateTime?>("UpdatedDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("updated_at");

                            b1.HasKey("PreparationEntityId");

                            b1.ToTable("preparation");

                            b1.WithOwner()
                                .HasForeignKey("PreparationEntityId");
                        });

                    b.Navigation("Audit")
                        .IsRequired();
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadEntity", b =>
                {
                    b.Navigation("Chefs");

                    b.Navigation("OfficesBreads");

                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.BreadInstanceEntity", b =>
                {
                    b.Navigation("BreadIngredients");

                    b.Navigation("BreadPreparation");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.ChefEntity", b =>
                {
                    b.Navigation("Office")
                        .IsRequired();
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.IngredientsEntity", b =>
                {
                    b.Navigation("BreadInstances");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OfficeEntity", b =>
                {
                    b.Navigation("OfficeBreads");

                    b.Navigation("OrderEntities");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderEntity", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.OrderItemEntity", b =>
                {
                    b.Navigation("BreadInstance")
                        .IsRequired();
                });

            modelBuilder.Entity("FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities.PreparationEntity", b =>
                {
                    b.Navigation("BreadInstances");
                });
#pragma warning restore 612, 618
        }
    }
}
