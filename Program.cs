using HotelBooking.Configuration;
using HotelBooking.Data.Context;
using HotelBooking.Endpoints;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//add services dependencies from configuration
builder.Services.AddServices();
builder.Services.AddControllers()
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var connectionString = builder.Configuration.GetConnectionString("SqlConnection");
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(connectionString));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionMiddleware();

app.UseHttpsRedirection();

app.MapGet("/api/v1/guests/details/{guestId}", GuestEndpoint.GetGuest);
app.MapPut("/api/v1/guests/details/update", GuestEndpoint.UpdateGuest);

app.MapGet("/api/v1/rooms/available", RoomEndpoint.GetAllAvailableRooms);

app.MapGet("/api/v1/bookings/{bookingId}", BookingEndpoint.GetBooking);
app.MapPost("/api/v1/guests/bookings/create", BookingEndpoint.CreateBooking);
app.MapGet("/api/v1/guests/{guestId}/bookings", BookingEndpoint.GetRelatedBookings);
app.MapDelete("/api/v1/bookings/{bookingId}/delete", BookingEndpoint.DeleteBooking);

app.Run();
