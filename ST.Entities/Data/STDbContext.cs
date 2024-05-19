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
                e.HasKey(x => x.Id);
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

            modelBuilder.Entity<Student>(e =>
            {
                e.ToTable("Student");
                e.HasKey(x => x.Id);
                e.Property(x => x.StudentName);
                e.Property(x => x.CreateBy);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.Gender);
                e.Property(x => x.DOB);
                e.Property(x => x.IsDeleted);

                e.HasOne(x => x.User)
            .WithMany(x => x.Students)
            .HasForeignKey(x => x.UserId)
            .HasConstraintName("FK_User_Student");

            });

            modelBuilder.Entity<Category>(e =>
            {
                e.ToTable("Category");
                e.HasKey(x => x.Id);
                e.Property(x => x.CategorytName);
                e.Property(x => x.CreateBy);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);
            });

            modelBuilder.Entity<Subject>(e =>
            {
                e.ToTable("Subject");
                e.HasKey(x => x.Id);
                e.Property(x => x.SubjectName);
                e.Property(x => x.CreateBy);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);


                e.HasOne(x => x.Category)
            .WithMany(x => x.Subjects)
            .HasForeignKey(x => x.CategoryID)
            .HasConstraintName("FK_Category_Subject");
            });

            modelBuilder.Entity<Course>(e =>
            {
                e.ToTable("Course");
                e.HasKey(x => x.Id);
                e.Property(x => x.Code);
                e.Property(x => x.CourseName);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);
                e.Property(x => x.DOB);
                e.Property(x => x.Title);
                e.Property(x => x.Description);
                e.Property(x => x.Price).HasColumnType("decimal(18,2)");
                e.Property(x => x.Quantity);
                e.Property(x => x.TotalSlot);
                e.Property(x => x.IsApproved);
                e.Property(x => x.IsActive);
                e.Property(x => x.StartDate);
                e.Property(x => x.EndDate);


                e.HasOne(x => x.Subject)
            .WithMany(x => x.Courses)
            .HasForeignKey(x => x.SubjectId)
            .HasConstraintName("FK_Subject_Course");
            });

            modelBuilder.Entity<Session>(e =>
            {
                e.ToTable("Sesion");
                e.HasKey(x => x.Id);
                e.Property(x => x.SessionName);
                e.Property(x => x.LearnDate);
                e.Property(x => x.CreateBy);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);
                e.Property(x => x.Title);
                e.Property(x => x.Description);


                e.HasOne(x => x.Course)
            .WithMany(x => x.Sessions)
            .HasForeignKey(x => x.CourseId)
            .HasConstraintName("FK_Course_Session");
            });

            modelBuilder.Entity<Package>(e =>
            {
                e.ToTable("Package");
                e.HasKey(x => x.Id);
                e.Property(x => x.PackageName);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);
                e.Property(x => x.StartDate);
                e.Property(x => x.EndDate);
                e.Property(x => x.PaymentMethod);
                e.Property(x => x.QuantityCourse);
                e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)"); 
                e.Property(x => x.IsActive);
      


                e.HasOne(x => x.Student)
            .WithMany(x => x.Packages)
            .HasForeignKey(x => x.StudentId)
            .HasConstraintName("FK_Student_Packages");
            });


            modelBuilder.Entity<CourseXPackage>(entity =>
            {
                entity.ToTable("CoursePackage");

                entity.HasKey(cp => new { cp.CourseId, cp.PackageId });

                entity.HasOne(cp => cp.Course)
                    .WithMany(c => c.CourseXPackages)
                    .HasForeignKey(cp => cp.CourseId);

                entity.HasOne(cp => cp.Package)
                    .WithMany(p => p.CourseXPackages)
                    .HasForeignKey(cp => cp.PackageId);
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Order");
                e.HasKey(x => x.Id);
                e.Property(x => x.CreateDate);
                e.Property(x => x.LastUpdatedBy);
                e.Property(x => x.LastUpdatedDate);
                e.Property(x => x.IsDeleted);
                e.Property(x => x.Amount);
                e.Property(x => x.TotalPrice).HasColumnType("decimal(18,2)"); ;
                e.Property(x => x.PaymentMethod);
                e.Property(x => x.TotalPrice);
                e.Property(x => x.Description);
                e.Property(x => x.IsDeleted);



      //          e.HasOne(x => x.Student)
    //        .WithMany(x => x.Orders)
     //       .HasForeignKey(x => x.StudentId)
     //       .HasConstraintName("FK_Student_Order");

                e.HasOne(x => x.Package)
             .WithMany(x => x.Orders)
             .HasForeignKey(x => x.PackagedId)
             .HasConstraintName("FK_Package_Order");
            });
        }
    }
}
