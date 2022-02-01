using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cofetarie.Entities
{
    public class CofetarieContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string> >
    {
        public CofetarieContext(DbContextOptions<CofetarieContext> options) : base(options) { }

        //configurarea dinainte de Dependency Injection
/*        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Cofetarie;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;MultipleActiveResultSets=true");
        }*/
        public DbSet<Product> Products { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //one to one
            builder.Entity<Product>()
                .HasOne(r => r.Recipe)
                .WithOne(p => p.Product);

            builder.Entity<RecipeIngredient>().HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            //many to many
            builder.Entity<RecipeIngredient>()
                .HasOne<Recipe>(ri => ri.Recipe)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);

            builder.Entity<RecipeIngredient>()
                .HasOne<Ingredient>(ri => ri.Ingredient)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            base.OnModelCreating(builder);

            //many to many
            builder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne<Order>(op => op.Order)
                .WithMany(p => p.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProduct>()
                .HasOne<Product>(op => op.Product)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.ProductId);

            //one to many
            builder.Entity<Client>()
                .HasMany(c => c.Orders)
                .WithOne(o => o.Client);
        }
    }
}
