using HotelBooking.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Endpoints;

public sealed class RoomEndpoint
{
    public static async Task<IResult> GetAllAvailableRooms(
        [FromServices] IRoomService _roomService)
    {
        var result = await _roomService.GetAvailableRoomsAsync();

        return Results.Ok(result);
    }
}
