using System.ComponentModel.DataAnnotations;

namespace HilaryHaircareAPI.Models;

public class Stylist
{
    public int Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}