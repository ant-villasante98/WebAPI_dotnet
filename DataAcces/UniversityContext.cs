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

}
