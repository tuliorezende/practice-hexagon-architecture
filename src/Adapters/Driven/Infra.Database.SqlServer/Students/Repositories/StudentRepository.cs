using Domain.Students.Entities;
using Domain.Students.Ports.Out;
using Microsoft.EntityFrameworkCore;

namespace Infra.Database.SqlServer.Students.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _dbContext;

    public StudentRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Student>> GetStudentsAsync(int skip = 0, int take = 10)
    {
        var students = new List<Student>();
        var studentEntities = await _dbContext.Students.Skip(skip).Take(take).ToListAsync();

        if (studentEntities?.Count == 0)
            return null;

        foreach (var studentEntity in studentEntities)
        {
            var academicalHistoryEntry =
                await _dbContext
                    .AcademicalHistory
                    .Where(ah => ah.StudentId == studentEntity.Id)
                    .ToListAsync();

            var academicalHistoryList = new List<AcademicalHistoryEntry>();

            foreach (var academicalHistoryEntryEntity in academicalHistoryEntry)
            {
                var historicalEntry = new AcademicalHistoryEntry(academicalHistoryEntryEntity.StudentId,
                    academicalHistoryEntryEntity.Year,
                    academicalHistoryEntryEntity.Discipline,
                    academicalHistoryEntryEntity.Score);

                academicalHistoryList.Add(historicalEntry);
            }

            var student = Student.Load(
                studentEntity.Id,
                studentEntity.Name,
                studentEntity.Address,
                studentEntity.PersonalDocument,
                studentEntity.Telephone,
                studentEntity.Email,
                academicalHistoryList);

            students.Add(student);
        }

        return students;
    }

    public async Task<string> CreateStudentAsync(Student student)
    {
        var studentEntity = new Infra.Database.SqlServer.Students.Entities.Student
        {
            Id = student.Id,
            Name = student.Name,
            Address = student.Address,
            Telephone = student.Telephone,
            Email = student.Email,
            PersonalDocument = student.PersonalDocument,
        };

        _dbContext.Students.Add(studentEntity);
        await _dbContext.SaveChangesAsync();

        return student.Id;
    }

    public async Task<Student?> GetStudentByIdAsync(string studentId)
    {
        var studentEntity = await _dbContext
            .Students
            .FirstOrDefaultAsync(s => s.Id == studentId);

        if (studentEntity is null)
            return null;

        var academicalHistoryEntry =
            await _dbContext
                .AcademicalHistory
                .Where(ah => ah.StudentId == studentId)
                .ToListAsync();

        var academicalHistoryList = new List<AcademicalHistoryEntry>();

        foreach (var academicalHistoryEntryEntity in academicalHistoryEntry)
        {
            var historicalEntry = new AcademicalHistoryEntry(academicalHistoryEntryEntity.StudentId,
                academicalHistoryEntryEntity.Year,
                academicalHistoryEntryEntity.Discipline,
                academicalHistoryEntryEntity.Score);

            academicalHistoryList.Add(historicalEntry);
        }

        var student = Student.Load(
            studentEntity.Id,
            studentEntity.Name,
            studentEntity.Address,
            studentEntity.PersonalDocument,
            studentEntity.Telephone,
            studentEntity.Email,
            academicalHistoryList);

        return student;
    }

    public async Task<string> UpdateStudentAsync(string studentId, Student student)
    {
        var entityToUpdate = await _dbContext.Students.FirstOrDefaultAsync(t => t.Id == studentId);

        if (entityToUpdate is null)
            return string.Empty;

        entityToUpdate.Update(studentId, student);
        _dbContext.Students.Update(entityToUpdate);

        await _dbContext.SaveChangesAsync();

        return studentId;
    }

    public async Task<bool> CreateAcademicalHistoryAsyncEntryAsync(Student student,
        AcademicalHistoryEntry academicalHistoryEntry)
    {
        var academicalHistoryEntity = new Entities.AcademicalHistoryEntry
        {
            Id = academicalHistoryEntry.Id,
            Score = academicalHistoryEntry.Score,
            Year = academicalHistoryEntry.Year,
            Discipline = academicalHistoryEntry.Discipline,
            StudentId = student.Id
        };

        await _dbContext.AcademicalHistory.AddAsync(academicalHistoryEntity);
        await _dbContext.SaveChangesAsync();

        return true;
    }
}