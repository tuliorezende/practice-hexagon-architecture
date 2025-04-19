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
        optionsBuilder.UseSqlServer("Data Source=localhost,1433;Database=PocHexagonArchitecture;Integrated Security=false;User ID=sa;Password=Numsey@Password!;");
        base.OnConfiguring(optionsBuilder);
    }
}