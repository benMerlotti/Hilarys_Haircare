using System.ComponentModel.DataAnnotations;

namespace HilaryHaircareAPI.Models;

public class Service
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public decimal Cost { get; set; }
}