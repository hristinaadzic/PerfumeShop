using Microsoft.EntityFrameworkCore;
using PerfumeShop.Domain;
using System;

namespace PerfumeShop.DataAccess
{
    public class Context : DbContext
    {

        public Context(DbContextOptions options=null) : base(options)
        {

        }
        //public Context(DbContextOptions options) : base(options)
        //{

        //}

        public Context()
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
            modelBuilder.Entity<ProductCategory>().HasKey(x => new { x.ProductId, x.CategoryId });
            modelBuilder.Entity<UserUseCase>().HasKey(x => new {x.UserId, x.UseCaseId});
            base.OnModelCreating(modelBuilder);
        }

        public IApplicationUser User { get; }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-MUTLEBOJ\SQLEXPRESS;Initial Catalog=perfumeshop;Integrated Security=True");
        //}

        public override int SaveChanges()
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.IsDeleted = false;
                            e.CreatedAt = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            e.UpdatedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }

            return base.SaveChanges();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Volume> Volumes { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductVolume> ProductVolumes { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderLine> OrderLines { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }


    }
}
