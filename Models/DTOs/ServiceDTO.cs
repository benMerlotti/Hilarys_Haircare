using System.ComponentModel.DataAnnotations;

namespace HilaryHaircareAPI.Models;

public class ServiceDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Cost { get; set; }
}

public class ServicePostDTO
{
    public int Id { get; set; }
}