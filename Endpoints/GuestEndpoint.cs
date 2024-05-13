using HotelBooking.DTO;
using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Endpoints;

public sealed class GuestEndpoint
{
    public static async Task<IResult> GetGuest(
        [FromRoute] int guestId,
        [FromServices] IGuestService guestService)
    {
        var guest = await guestService.GetGuestAsync(guestId);

        return Results.Ok(guest);
    }
    public static async Task<IResult> UpdateGuest(
        [FromBody] UpdateGuestRequest request,
        [FromServices] IGuestService guestService)
    {
        await guestService.UpdateGuestAsync(request);
        return Results.Ok(new { Message = "Guest's profile succesfully updated" });
    }
}