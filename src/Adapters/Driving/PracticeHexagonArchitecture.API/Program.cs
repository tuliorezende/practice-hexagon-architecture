using System.Reflection;
using Application.Courses.Services;
using Application.Students.Services;
using Domain.Courses.Ports.In;
using Domain.Courses.Ports.Out;
using Domain.Students.Ports.In;
using Domain.Students.Ports.Out;
using Infra.Database.Memory.Courses.Repositories;
using Infra.Database.Memory.Students.Repositories;
using Infra.Database.SqlServer;
using Microsoft.EntityFrameworkCore;
using TeacherRepository = Infra.Database.SqlServer.Courses.Repositories.TeacherRepository;

namespace PracticeHexagonArchitecture.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));        
        
        builder.Services.AddSingleton<IStudentManager, StudentManager>();
        builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

        builder.Services.AddTransient<ITeacherManager, TeacherManager>();
        builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
        // builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
        
        builder.Services.AddTransient<ICourseManager, CourseManager>();
        builder.Services.AddTransient<ICourseRepository, CourseRepository>();

        var app = builder.Build();

        // Execute migrations automatically on app startup
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}