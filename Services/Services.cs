using Primer_proyecto.Models.DataModels;
namespace Primer_proyecto.Services;
public class Services
{
    public User[] users = new[] {
            new User(){Email="antonio@email.com",Name="Antonio",Id=1,LastName="Villasante",CreateBy="Antonio",Password="123456"},
            new User(){Email="raul@email.com",Name="Raul",Id=3,LastName="Gell",CreateBy="Raul",Password="0987"},
            };
    public Curso[] cursos = new[]{

        new Curso() { Id = 2,Name = "fisica",level = Level.Medium},
        new Curso() { Id = 3,Name = "estadistica",level = Level.Medium},
        new Curso() { Id = 5,Name = "ingles",level = Level.Basic},
        new Curso(){Id=1,Name="matematica",level= Level.Advanced}

    };
    public Student[] students = new[] {
        new Student(){Id=2,FirstName="Antonio",LastName="Villasante",Cursos={new Curso{Id=1}},Dob= new DateTime(1998,5,2)},
        new Student(){Id=4,FirstName="Miguel",LastName="Raq",Cursos={ new Curso{Id=2}},Dob=new DateTime(1999,2,4)},
    };
    public void UsuariosPorEmail(string str)
    {
        var result = users.First(u => u.Email.ToLower() == str.ToLower());
        Console.WriteLine($"Usuario id: {result.Id}, Nombre: {result.Name}, Email: {result.Email}");
    }
    public void AlumnosMayores()
    {
        var result = students.Where(s => s.Dob.Year > (DateTime.Now.Year - 18));
        foreach (Student stu in result)
        {
            Console.WriteLine($"Alumno : {stu.Id}, Nombre: {stu.FirstName}, Apellido: {stu.LastName}");
        }
    }

    public void CursoDeterminadoNivelAlMenosUnAlumno(Level nivel)
    {
        var result = cursos.Where(c => c.level == nivel && c.Students.Any());
    }
    public void CursoDeterminadoNivelYCategoria(Level nivel, string category)
    {
        var result = cursos.Where(c => c.level == nivel && c.Categories.Any(cat => cat.Name.ToLower() == category.ToLower()));
    }
    public void CursosSinAlumnos()
    {
        var result = cursos.Where(c => !c.Students.Any());
    }
}
