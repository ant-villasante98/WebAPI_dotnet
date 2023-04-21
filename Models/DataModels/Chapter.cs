﻿using System.ComponentModel.DataAnnotations;
namespace Primer_proyecto.Models.DataModels;
public class Chapter : BaseEntity
{
    public int CursoId { get; set; }
    public virtual Curso Curso { get; set; }
    [Required]
    public string List { get; set; } = string.Empty;
}
