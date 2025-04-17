using System.Reflection;
using Application.Courses;
using Application.Courses.Services;
using Application.Students;
using Application.Students.Services;
using Domain.Courses.Ports;
using Domain.Courses.Ports.In;
using Domain.Courses.Ports.Out;
using Domain.Students.Ports;
using Domain.Students.Ports.In;
using Domain.Students.Ports.Out;
using Infra.Database.Memory.Courses.Repositories;
using Infra.Database.Memory.Students.Repositories;

namespace PracticeHexagonArchitecture.API;

public class Program
{
    public static void Main(string[] args)
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

        builder.Services.AddSingleton<IStudentManager, StudentManager>();
        builder.Services.AddSingleton<IStudentRepository, StudentRepository>();

        builder.Services.AddSingleton<ITeacherManager, TeacherManager>();
        builder.Services.AddSingleton<ITeacherRepository, TeacherRepository>();
        
        builder.Services.AddSingleton<ICourseManager, CourseManager>();
        builder.Services.AddSingleton<ICourseRepository, CourseRepository>();
        
        var app = builder.Build();

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