using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Primer_proyecto.Models.DataModels;

namespace Primer_proyecto.DataAcces;
public class UniversityDBContext : DbContext
{
    public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options)
    {

    }
    //TODO : add Dbsets
    public DbSet<User>? Users { get; set; }
    public DbSet<Curso>? Cursos { get; set; }
    public DbSet<Category>? Categories { get; set; }
    public DbSet<Student>? Students { get; set; }
    public DbSet<Chapter>? Chapter { get; set; }

}
