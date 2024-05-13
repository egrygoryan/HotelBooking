using HotelBooking.Data.Repositories;
using HotelBooking.Data.Repositories.Interfaces;
using HotelBooking.Services;
using HotelBooking.Services.Interfaces;

namespace HotelBooking.Configuration;

public static class HotelBookingConfigurationExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
        => services
            .AddScoped<IBookingRepository, BookingRepository>()
            .AddScoped<IGuestRepository, GuestRepository>()
            .AddScoped<IRoomRepository, RoomRepository>()
            .AddTransient<IBookingService, BookingService>()
            .AddTransient<IGuestService, GuestService>()
            .AddTransient<IRoomService, RoomService>();
}