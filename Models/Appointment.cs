using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace HilaryHaircareAPI.Models;

public class Appointment
{
    public int Id { get; set; }
    [Required]
    public DateTime ScheduledTime { get; set; }
    [Required]
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    [Required]
    public int StylistId { get; set; }
    public Stylist Stylist { get; set; }
    public decimal TotalCost { get; set; }
    public bool IsCancelled { get; set; }
    [Required]
    [JsonIgnore]
    public List<Service> Services { get; set; }
}