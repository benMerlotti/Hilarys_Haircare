using System.ComponentModel.DataAnnotations;

namespace HilaryHaircareAPI.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public DateTime ScheduledTime { get; set; }
    [Required]
    public int CustomerId { get; set; }
    [Required]
    public int StylistId { get; set; }
    public decimal TotalCost { get; set; }
    public bool IsCancelled { get; set; }
}