using System.ComponentModel.DataAnnotations;

namespace Primer_proyecto.Models.DataModels;
public class BaseEntity
{
    [Required]
    [Key]
    public int Id { get; set; }
    public string CreateBy { get; set; } = string.Empty;
    public string UpdateBy { get; set; } = string.Empty;
    public DateTime? UpdateAt { get; set; }
    public string DeleteBy { get; set; } = string.Empty;
    public DateTime? DeleteAt { get; set; }
    public bool IsDeleted { get; set; } = false;

}
