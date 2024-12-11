using System.ComponentModel.DataAnnotations;

namespace HilaryHaircareAPI.Models;

public class AppointmentService
{
    public int Id { get; set; }
    public int AppointmentId { get; set; }
    public int ServiceId { get; set; }
}