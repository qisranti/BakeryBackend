using FinalBakery.Infrastructure.Persistence.PostgreSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalBakery.Infrastructure.Persistence.PostgreSQL
{
    public class AppDbContext: DbContext
    {
        public virtual DbSet<IngredientsEntity> Ingredients { get; set; }
        public virtual DbSet<PreparationEntity> Preparations { get; set; }
        public virtual DbSet<BreadEntity> Breads { get; set; }
        public virtual DbSet<BreadInstanceIngredientEntity> BreadIngredients { get; set; }
        public virtual DbSet<BreadInstancePreparationEntity> BreadPreparation { get; set; }
        public virtual DbSet<OrderItemEntity> OrderItems { get; set; }
        public virtual DbSet<OrderEntity> Orders { get; set; }
        public virtual DbSet<ChefEntity> Chefs { get; set; }
        public virtual DbSet<OfficeEntity> Offices { get; set; }
        public virtual DbSet<OfficeBreadEntity> OfficeBreads { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }

    }
}
