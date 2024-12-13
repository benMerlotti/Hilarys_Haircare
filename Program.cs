using HilaryHaircareAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Json;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

// allows passing datetimes without time zone data 
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// allows our api endpoints to access the database through Entity Framework Core
builder.Services.AddNpgsql<HilaryHaircareDbContext>(builder.Configuration["HilaryHaircareDbConnectionString"]);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyMethod();
                    options.AllowAnyHeader();
                });

}

app.UseHttpsRedirection();

app.MapGet("/customers", (HilaryHaircareDbContext db) =>
{

    try
    {
        var customers = db.Customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            FirstName = c.FirstName,
            LastName = c.LastName,
            Email = c.Email
        }).ToList();

        if (customers == null || !customers.Any())
        {
            return Results.NotFound("No customers found.");
        }

        return Results.Ok(customers);
    }
    catch (Exception ex)
    {
        // Log the exception if necessary
        return Results.Problem("An error occurred while fetching customers: " + ex.Message);
    }
});

app.MapGet("/stylists", (HilaryHaircareDbContext db) =>
{

    try
    {
        var stylists = db.Stylists.Select(s => new StylistDTO
        {
            Id = s.Id,
            FirstName = s.FirstName,
            LastName = s.LastName,
            Email = s.Email
        }).ToList();

        if (stylists == null || !stylists.Any())
        {
            return Results.NotFound("No stylists found.");
        }

        return Results.Ok(stylists);
    }
    catch (Exception ex)
    {
        // Log the exception if necessary
        return Results.Problem("An error occurred while fetching customers: " + ex.Message);
    }
});

app.MapGet("/services", (HilaryHaircareDbContext db) =>
{

    try
    {
        var services = db.Services.Select(s => new ServiceDTO
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Cost = s.Cost
        }).ToList();

        if (services == null || !services.Any())
        {
            return Results.NotFound("No services found.");
        }

        return Results.Ok(services);
    }
    catch (Exception ex)
    {
        // Log the exception if necessary
        return Results.Problem("An error occurred while fetching customers: " + ex.Message);
    }
});

app.MapGet("/appointments", (HilaryHaircareDbContext db) =>
{

    try
    {
        var appointments = db.Appointments
        .Include(a => a.Customer)
        .Include(a => a.Stylist)
        .Include(a => a.Services)
        .Select(a => new AppointmentDTO
        {
            Id = a.Id,
            CustomerId = a.CustomerId,
            Customer = new CustomerDTO
            {
                Id = a.Customer.Id,
                FirstName = a.Customer.FirstName,
                LastName = a.Customer.LastName,
                Email = a.Customer.Email

            },
            StylistId = a.StylistId,
            Stylist = new StylistDTO
            {
                Id = a.Stylist.Id,
                FirstName = a.Stylist.FirstName,
                LastName = a.Stylist.LastName,
                Email = a.Stylist.Email
            },
            Services = a.Services.Select(s => new ServiceDTO
            {
                Id = s.Id,
                Name = s.Name,
                Description = s.Description,
                Cost = s.Cost
            }).ToList(),
            ScheduledTime = a.ScheduledTime,
            TotalCost = a.Services.Sum(s => s.Cost),
            IsCancelled = a.IsCancelled

        }).ToList();

        if (appointments == null || !appointments.Any())
        {
            return Results.NotFound("No appointments found.");
        }

        return Results.Ok(appointments);
    }
    catch (Exception ex)
    {
        // Log the exception if necessary
        return Results.Problem("An error occurred while fetching customers: " + ex.Message);
    }
});

app.MapPost("/schedule-appointment", async (HilaryHaircareDbContext db, AppointmentPostDTO newAppointment) =>
{

    var serviceIds = newAppointment.Services
        .Select(a => a.Id)
        .ToList();

    // Fetch the services from the database
    List<Service> services = await db.Services.Where(s => serviceIds.Contains(s.Id)).ToListAsync();

    Appointment newerAppointment = new Appointment
    {
        ScheduledTime = newAppointment.ScheduledTime,
        CustomerId = newAppointment.CustomerId,
        StylistId = newAppointment.StylistId,
        Services = services
    };

    await db.Appointments.AddAsync(newerAppointment);
    await db.SaveChangesAsync();

    return Results.Created($"/appointments/{newerAppointment.Id}", newerAppointment);
});

app.MapPut("/toggle-status/{id}", (HilaryHaircareDbContext db, int id) =>
{
    Appointment selectedApp = db.Appointments.FirstOrDefault(a => id == a.Id);

    if (selectedApp == null)
    {
        return Results.NotFound("Appointment not found.");
    }
    if (selectedApp.IsCancelled == true)
    {
        selectedApp.IsCancelled = false;
    }
    else
    {
        selectedApp.IsCancelled = true;
    }

    db.SaveChanges();
    return Results.Ok(new { message = "Appointment status updated.", id = selectedApp.Id });
});

app.MapPut("/edit-services", (HilaryHaircareDbContext db, UpdateAppointmentDTO updateRequest) =>
{
    var selectedApp = db.Appointments.Include(a => a.Services).FirstOrDefault(a => updateRequest.Id == a.Id);

    if (selectedApp == null)
    {
        return Results.NotFound("Appointment not found.");
    }

    // Ensure the Services collection is initialized
    if (selectedApp.Services == null)
    {
        selectedApp.Services = new List<Service>(); // Initialize the collection if it's null
    }


    // Clear existing services
    selectedApp.Services.Clear();

    // Retrieve new services
    var services = db.Services.Where(s => updateRequest.Services.Contains(s.Id)).ToList();

    // Add new services to the appointment
    selectedApp.Services.AddRange(services);

    db.SaveChanges();

    return Results.Ok(selectedApp);
});

app.MapPut("stylists/toggle-status/{id}", (HilaryHaircareDbContext db, int id) =>
{
    Stylist foundStylist = db.Stylists.FirstOrDefault(s => s.Id == id);

    if (foundStylist.IsActive == true)
    {
        foundStylist.IsActive = false;
    }
    else
    {
        foundStylist.IsActive = true;
    }

    db.SaveChanges();

    return Results.Ok(foundStylist);
});

app.MapPost("customers/add-customer", (HilaryHaircareDbContext db, Customer customer) =>
{
    db.Customers.Add(customer);
    db.SaveChanges();

    return Results.Created($"customers/${customer.Id}", customer);
});



app.Run();