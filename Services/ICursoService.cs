using Primer_proyecto.Models.DataModels;
namespace Primer_proyecto.Services;
public interface ICursoService
{
    public IEnumerable<Curso> GetCursosByCategory();

    public IEnumerable<Curso> GetCursosSinTemario();

    public IEnumerable<Curso> GetCursoTemario();
    public IEnumerable<Curso> GetCursoByStudent();


}
