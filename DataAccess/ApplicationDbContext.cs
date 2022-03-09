using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Entities;
using DataAcces;
using Microsoft.AspNetCore.Identity;

namespace DataAcces
{
    public class ApplicationDbContext : IdentityDbContext<EcommerceUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categories> Categoryes { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<EcommerceUser> eCommerceUsers { get; set; }
        public DbSet<ProductPicture> ProductPictures { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<EcommerceUser>().ToTable("Users");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id="abcdef",
                    Name="Admin",
                    ConcurrencyStamp="sjsjsjs123",
                    NormalizedName="ADMIN"
                }

                );
            var user = new EcommerceUser
              
                {
                    Id="1",
                    FirstName="Admin",
                    LastName="Admin",
                    UserName="admin@gmail.com",
                    EmailConfirmed=true,
                    Adress="baki nizami",
                    NormalizedEmail="ADMIN@GMAIL.COM",
                    NormalizedUserName = "ADMINGMAIL.COM",
                    PhoneNumber = "0554770076",
                    PhoneNumberConfirmed=false,
                    TwoFactorEnabled=false,
                    ConcurrencyStamp="alertsg123",
                    AccessFailedCount=0,
                    LockoutEnabled=false,
                };

            PasswordHasher < EcommerceUser>passwordHasher=new();
            passwordHasher.HashPassword(user, "Admin_123");
            modelBuilder.Entity<EcommerceUser>().HasData(user);
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                  RoleId= "abcdef",
                  UserId=user.Id,
                }
                );
        }
    }
}