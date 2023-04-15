using System.ComponentModel.DataAnnotations;
namespace Primer_proyecto;
public class UserLogins
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }
}
