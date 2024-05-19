using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ST.Entities.Data.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ST.Entities.Data
{
    public class STDbContext : DbContext
    {
        public STDbContext()
        {

        }
        public STDbContext(DbContextOptions<STDbContext> options) : base(options)
        {


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = /*config["ConnectionStrings:DB"]*/ config.GetConnectionString("SmartThrive");

            return strConn;
        }
        #region Dbset
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(x => x.UserID);
                e.Property(x => x.UserName).IsRequired();
                e.Property(x => x.Email).IsRequired();
                e.Property(x => x.Password).IsRequired();
                e.Property(x => x.Status);
                e.Property(x => x.Address);
                e.Property(x => x.FullName);
                e.Property(x => x.DOB);
                e.Property(x => x.Gender);
                e.Property(x => x.Phone);

                e.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleID)
                .HasConstraintName("FK_User_Role");

                e.HasOne(x => x.Location)
               .WithMany(x => x.Users)
               .HasForeignKey(x => x.LocationID)
               .HasConstraintName("FK_User_Location");
            });
            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasKey(x => x.Id);
                e.Property(x => x.RoleName).IsRequired();
                e.Property(x => x.CreatedDate);
                e.Property(x => x.UpdatedDate);
                e.Property(x => x.IsDeleted);
            });

            modelBuilder.Entity<Location>(e =>
            {
                e.ToTable("Location");
                e.HasKey(x => x.Id);
                e.Property(x => x.Country);
                e.Property(x => x.City);
                e.Property(x => x.District);
                e.Property(x => x.Ward);
                e.Property(x => x.isDeleted);
            });

            
        }
    }
}
