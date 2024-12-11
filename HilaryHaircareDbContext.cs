using Microsoft.EntityFrameworkCore;
using HilaryHaircareAPI.Models;

public class HilaryHaircareDbContext : DbContext
{

    public DbSet<Stylist> Stylists { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<AppointmentService> AppointmentServices { get; set; }


    public HilaryHaircareDbContext(DbContextOptions<HilaryHaircareDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Stylists
        modelBuilder.Entity<Stylist>().HasData(
            new Stylist { Id = 1, FirstName = "Alice", LastName = "Smith", Email = "alice@example.com", IsActive = true },
            new Stylist { Id = 2, FirstName = "Bob", LastName = "Jones", Email = "bob@example.com", IsActive = true },
            new Stylist { Id = 3, FirstName = "Charlie", LastName = "Brown", Email = "charlie@example.com", IsActive = false }
        );

        // Seed Services
        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Name = "Haircut", Description = "Basic haircut", Cost = 25.00m },
            new Service { Id = 2, Name = "Coloring", Description = "Full hair coloring", Cost = 75.00m },
            new Service { Id = 3, Name = "Beard Trim", Description = "Beard shaping and trimming", Cost = 15.00m }
        );

        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer { Id = 1, FirstName = "Emma", LastName = "Johnson", Email = "emma@example.com" },
            new Customer { Id = 2, FirstName = "Liam", LastName = "Williams", Email = "liam@example.com" }
        );

        // Seed Appointments
        modelBuilder.Entity<Appointment>().HasData(
            new Appointment
            {
                Id = 1,
                ScheduledTime = new DateTime(2024, 12, 12, 10, 0, 0), // Date + Time
                CustomerId = 1,
                StylistId = 1,
                TotalCost = 40.00m,
                IsCancelled = false
            },
            new Appointment
            {
                Id = 2,
                ScheduledTime = new DateTime(2024, 12, 13, 11, 0, 0), // Date + Time
                CustomerId = 2,
                StylistId = 2,
                TotalCost = 75.00m,
                IsCancelled = true
            }
        );

        // Seed AppointmentServices
        modelBuilder.Entity<AppointmentService>().HasData(
            new AppointmentService { Id = 1, AppointmentId = 1, ServiceId = 1 },
            new AppointmentService { Id = 2, AppointmentId = 1, ServiceId = 3 },
            new AppointmentService { Id = 3, AppointmentId = 2, ServiceId = 2 }
        );
    }
}