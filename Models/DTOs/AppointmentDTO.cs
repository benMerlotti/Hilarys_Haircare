using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.SignalR;

namespace HilaryHaircareAPI.Models;

public class AppointmentDTO
{
    public int Id { get; set; }
    public DateTime ScheduledTime { get; set; }
    public int CustomerId { get; set; }
    public CustomerDTO Customer { get; set; }
    public int StylistId { get; set; }
    public StylistDTO Stylist { get; set; }
    public decimal TotalCost { get; set; }
    public bool IsCancelled { get; set; }
    public List<ServiceDTO> Services { get; set; }
}

public class AppointmentPostDTO
{
    public DateTime ScheduledTime { get; set; }
    public int CustomerId { get; set; }
    public int StylistId { get; set; }
    public List<ServicePostDTO> Services { get; set; }
}

public class AppointmentEditServiceDTO
{
    public List<ServicePostDTO> Services { get; set; }
}

public class UpdateAppointmentDTO
{
    public int Id { get; set; }
    public List<int> Services { get; set; }
}