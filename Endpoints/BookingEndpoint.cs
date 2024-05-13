using HotelBooking.DTO;
using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Endpoints;

public sealed class BookingEndpoint
{
    public static async Task<IResult> CreateBooking(
        [FromBody] CreateBookingRequest request,
        IBookingService bookingService)
    {
        await bookingService.CreateBookingAsync(request);
        return Results.Created();
    }

    public static async Task<IResult> DeleteBooking(
        [FromBody] DeleteBookingRequest request,
        [FromServices] IBookingService bookingService)
    {
        await bookingService.DeleteBookingAsync(request);
        return Results.Ok(new { Message = "Booking deleted succesfully" });
    }

    public static async Task<IResult> GetRelatedBookings(
        [FromRoute] int guestId,
        [FromServices] IBookingService bookingService)
    {
        var results = await bookingService.GetRelatedBookingsAsync(guestId);
        return Results.Ok(results);
    }

    public static async Task<IResult> GetBooking(
        [FromRoute] int bookingId,
        [FromServices] IBookingService bookingService)
    {
        var result = await bookingService.GetBookingAsync(bookingId);
        return Results.Ok(result);
    }
}
