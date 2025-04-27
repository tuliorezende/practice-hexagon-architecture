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
using Microsoft.OpenApi.Models;
using CourseRepository = Infra.Database.SqlServer.Courses.Repositories.CourseRepository;
using StudentRepository = Infra.Database.SqlServer.Students.Repositories.StudentRepository;
using TeacherRepository = Infra.Database.SqlServer.Courses.Repositories.TeacherRepository;

namespace PracticeHexagonArchitecture.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Configuration.AddEnvironmentVariables();
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            // using System.Reflection;
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });

        //Uso via variavel de ambiente (Double underscore para representar o nível): ConnectionStrings__DefaultConnection

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.AddTransient<IStudentManager, StudentManager>();
        builder.Services.AddTransient<IStudentRepository, StudentRepository>();
        // builder.Services.AddTransient<IStudentRepository, StudentRepository>();

        builder.Services.AddTransient<ITeacherManager, TeacherManager>();
        builder.Services.AddTransient<ITeacherRepository, TeacherRepository>();
        // builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();

        builder.Services.AddTransient<ICourseManager, CourseManager>();
        builder.Services.AddTransient<ICourseRepository, CourseRepository>();
        // builder.Services.AddTransient<ICourseRepository, CourseRepository>();

        builder.Services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Pegasus School API",
                Version = "v1",
                Description = "API para gerenciamento de cursos e alunos da Pegasus School",
                Contact = new OpenApiContact
                {
                    Name = "Tulio (Testing Purposes)",
                    Url = new Uri("https://github.com/tuliorezende/practice-hexagon-architecture")
                }
            });
        });

        var app = builder.Build();

        // Execute migrations automatically on app startup
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await db.Database.MigrateAsync();
        }

        // Configure the HTTP request pipeline.

        app.UseSwagger();
        app.UseSwaggerUI(s =>
        {
            s.SwaggerEndpoint("../swagger/v1/swagger.json", "Pegasus School API");
            s.RoutePrefix = string.Empty;
            s.DocumentTitle = "Pegasus API | Swagger";
        });

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}