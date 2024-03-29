﻿using Primer_proyecto.Models.DataModels;
namespace Primer_proyecto.Services;
public interface IStudentService
{
    IEnumerable<Student> GetStudentsWhitCourses();

    IEnumerable<Student> GetStudentsSinCurso();

    IEnumerable<Student> GetStudentsByCurso();

}
