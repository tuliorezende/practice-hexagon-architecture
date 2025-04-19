using Domain.Students.ValueObjects;
using Infra.Database.SqlServer.Courses;
using Infra.Database.SqlServer.Students;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SqlServer;

public class AppDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<AcademicalHistoryEntry> AcademicalHistory { get; set; }

    public DbSet<ClassMaterialEntry> ClassMaterialEntry { get; set; }

    public DbSet<Teacher> Teachers { get; set; }

    public DbSet<Course> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost,1433;Database=PocHexagonArchitecture;Integrated Security=false;User ID=sa;Password=Numsey@Password!;TrustServerCertificate=true");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .HasOne(c => c.Teacher)
            .WithMany(c => c.Courses)
            .HasForeignKey(c => c.TeacherId);

        modelBuilder.Entity<Teacher>()
            .HasMany(t => t.Courses)
            .WithOne(t => t.Teacher)
            .HasForeignKey(t => t.TeacherId);

        modelBuilder.Entity<ClassMaterialEntry>()
            .HasMany(c => c.Courses)
            .WithMany(c => c.Materials);

        modelBuilder.Entity<Student>()
            .HasMany(s => s.AcademicalHistory)
            .WithOne(s => s.Student)
            .HasForeignKey(s => s.StudentId);

        modelBuilder.Entity<AcademicalHistoryEntry>()
            .HasOne(a => a.Student)
            .WithMany(a => a.AcademicalHistory)
            .HasForeignKey(a => a.StudentId);
        
        base.OnModelCreating(modelBuilder);
    }
}