using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto.DataAcces;
public class UniversityDBContext : DbContext
{
    private readonly ILoggerFactory _loggerFactory;

    public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
    {
        _loggerFactory = loggerFactory;
    }
    //TODO : add Dbsets
    public DbSet<User>? Users { get; set; }
    public DbSet<Curso>? Cursos { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Chapter>? Chapters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
        //optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Warning)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

}
